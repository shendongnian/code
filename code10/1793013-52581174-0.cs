    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dateString = "Dec 30 2006 12:38AM";
                var date = DateTime.Parse(dateString);
                Console.WriteLine(date);
                // results is 30/12/2006 00:38:00 (according to my DateTime format settings)
                Console.ReadLine();
            }
        }
    }
