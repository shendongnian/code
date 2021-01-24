    using System;
    using System.Collections.ObjectModel;
    
    namespace C_TaskManager
    {
        public class UserTask
        {
            public UserTask(string Description)
            {
                this.UserInput = Description;
            }
            public string UserInput { get; set; }
            public override string ToString()
            {
                return UserInput;
            }
        }
        public class TaskManager
        {
            public ObservableCollection<UserTask> UserTasks { get; set; } = new ObservableCollection<UserTask>();
        }
    }
    
    namespace C_TaskManager
    {
        internal class Program
        {
            private static string ReadTextLineFromConsole()
            {
                return Console.ReadLine();
            }
            private static int ReadInt32FromConsole()
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    return -1;
                }
            }
    
            private static TaskManager tm = new TaskManager();
            private static void Main(string[] args)
            {
                int num = 0;
                do
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.WriteLine("Please select what you would like to do");
                    Console.WriteLine("1. Add A Task");
                    Console.WriteLine("2. Remove A Task");
                    Console.WriteLine("3. Update A Task");
                    Console.WriteLine("4. View Task");
                    Console.WriteLine("5. List Tasks");
                    Console.WriteLine("6. EXIT");
                    Console.WriteLine("---------------------------------------");
    
                    num = ReadInt32FromConsole();
    
                    switch (num)
                    {
                        case -1:
                            Console.WriteLine("Invalid entry. Try again.");
                            break;
    
                        case 1:
                            {
                                Console.WriteLine("Please enter a new Task:");
                                var input = ReadTextLineFromConsole();
    
                                var ut = new UserTask(input);
    
                                tm.UserTasks.Add(ut);
                                Console.WriteLine($"New Task: {ut.ToString()}");
                            }
                            break;
    
                        case 2:
                            {
                                Console.WriteLine("Remove Task by index position:");
                                var input = ReadInt32FromConsole();
    
                                tm.UserTasks.RemoveAt(input);
                                Console.WriteLine("Task removed");
                            }
                            break;
                        case 3:
                            {
                                Console.WriteLine("Update Task by index position:");
                                var input = ReadInt32FromConsole();
                                // TODO: check if input is in range of UserTasks
    
                                var selectedTask = tm.UserTasks[input];
    
                                Console.WriteLine("Please enter a new Task Description:");
                                var NewDescription = ReadTextLineFromConsole();
                                selectedTask.UserInput = NewDescription;
                                Console.WriteLine("Task updated");
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("View Task by index position:");
                                var input = ReadInt32FromConsole();
    
                                var selectedTask = tm.UserTasks[input];
                                Console.WriteLine(selectedTask.UserInput);
                            }
                            break;
                        case 5:
                            {
                                Console.WriteLine("List Tasks:");
                                foreach (var ut in tm.UserTasks)
                                {
                                    Console.WriteLine(" * " + ut.UserInput);
                                }
                            }
                            break;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("////////////////////////////////////////////////////");
                    Console.WriteLine("Press a key to return to main menu...");
                    Console.ReadKey();
                } while (num != 6);
    
            }
    
    
        }
    
    
    }
