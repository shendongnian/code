                    case "1":
                        {
                            Console.WriteLine("Adding new student.");
                            Console.WriteLine("Enter new student name: ");                            
                            string name = Console.ReadLine();
                            management.AddStudent(new Student(){Name = name});
                            Console.ReadKey();
                            break;
                        }
