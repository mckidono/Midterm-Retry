using System;
using NLog.Web;

namespace TicketClasses
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            Console.WriteLine("1) Output CSV records.");
            Console.WriteLine("2) Add CSV record. (Legacy code -> tickets.csv");
            Console.WriteLine("3) Bug/Defect");
            Console.WriteLine("4) Enhancement");
            Console.WriteLine("5) Task");

            int.TryParse(Console.ReadLine(), out var inputNum);

            try
            {
                if (inputNum == 1)
                {
                    Console.WriteLine("(B)ugs  |  (E)nhancements  |  (T)asks");
                    var key = Console.ReadLine().ToUpper();

                    if (key == "B")
                    {
                        TicketFileHandler file = new TicketFile("tickets.csv");
                        file.ReadFromFile();
                    }
                    else if (key == "E")
                    {
                        TicketFileHandler file = new EnhancementFile("enhancements.csv");
                        file.ReadFromFile();
                    }
                    else if (key == "T")
                    {
                        TicketFileHandler file = new TaskFile("tasks.csv");
                        file.ReadFromFile();
                    }
                }


                if (inputNum == 2 || inputNum == 3)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Severity>");
                    var severity = Console.ReadLine();

                    var ticket = new Bug(severity, id, summary, status, priority, submitter, assigned, watching);
                    TicketFileHandler file = new TicketFile("tickets.csv");
                    file.WriteToFile(ticket);
                }

                if (inputNum == 4)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Software>");
                    var software = Console.ReadLine();

                    Console.Write("Cost>");
                    double.TryParse(Console.ReadLine(), out var cost);

                    Console.Write("Reason>");
                    var reason = Console.ReadLine();

                    Console.Write("Estimate>");
                    double.TryParse(Console.ReadLine(), out var estimate);

                    var enhancement = new Enhancement(software, cost, reason, estimate, id, summary, status,
                        priority, submitter, assigned, watching);

                    var file = new EnhancementFile("enhancements.csv");
                    file.WriteToFile(enhancement);
                }

                if (inputNum == 5)
                {
                    Console.Write("Ticket ID>");
                    var id = Console.ReadLine();

                    Console.Write("Summary>");
                    var summary = Console.ReadLine();

                    Console.Write("Status>");
                    var status = Console.ReadLine();

                    Console.Write("Priority>");
                    var priority = Console.ReadLine();

                    Console.Write("Submitter>");
                    var submitter = Console.ReadLine();

                    Console.Write("Assigned>");
                    var assigned = Console.ReadLine();

                    Console.Write("Watching>");
                    var watching = Console.ReadLine();

                    Console.Write("Project Name>");
                    var projectName = Console.ReadLine();

                    Console.Write("Due Date>");
                    var due = Convert.ToDateTime(Console.ReadLine());

                    var task = new Task(projectName, due, id, summary, status, priority, submitter, assigned,
                        watching);

                    var file = new TaskFile("tasks.csv");
                    file.WriteToFile(task);
                }
                else if (inputNum == 6)
                {
                    Console.WriteLine("1) search status");
                    Console.WriteLine("2) search Priority");
                    Console.WriteLine("3) search Submitter");

                    inputNum = Console.Read();
                    if(inputNum == 1){
                         Console.WriteLine("Enter your search term:");
                         System.Console.Write(">");
                         string Search = Console.ReadLine();
                         var statuses = TicketFile.tickets.Where(t => t.status.Contains(Search)).Select(t => t.status);
                         Console.WriteLine($"There are {status.Count()} movies with "+Search+" in the title:");
                         foreach(string s in status)
                         {
                             Console.WriteLine($"  {t}");
                         }
                    }

                    else if(inputNum == 2){
                         Console.WriteLine("Enter your search term:");
                         System.Console.Write(">");
                         string Search = Console.ReadLine();
                         var Priorities = TicketFile.tickets.Where(t => t.priority.Contains(Search)).Select(t => t.priority);
                         Console.WriteLine($"There are {priority.Count()} movies with "+Search+" in the title:");
                         foreach(string p in priority)
                         {
                             Console.WriteLine($"  {t}");
                         }
                    }
                    else{
                        Console.WriteLine("Enter your search term:");
                         System.Console.Write(">");
                         string Search = Console.ReadLine();
                         var Submitters = TicketFile.tickets.Where(t => t.submitter.Contains(Search)).Select(t => t.submitter);
                         Console.WriteLine($"There are {submitter.Count()} movies with "+Search+" in the title:");
                         foreach(string s in submitter)
                         {
                             Console.WriteLine($"  {t}");
                         }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}