    using System;
    
    namespace MyConto
    {
        public class NewUser
        {
            public static void NewUserRegistration()
            {
                Console.Write("Username: ");
                string user = Console.ReadLine();
    
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                while (pass.Length > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insert a valid password (max 5 chars)\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Password: ");
                    pass= Console.ReadLine();
                }     
            }
        }
    }
