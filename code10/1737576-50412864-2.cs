    using System;
    
    class Program
    {
        public static void Main()
        {
            object obj = 200;
            switch (obj)
            {
                case int x when Log("First when", x < 10):
                    Console.WriteLine("First case");
                    break;
                case string y when Log("Second when", y == "This won't happen"):
                    Console.WriteLine("Second case");
                    break;
                case int z when Log("Third when", true):
                    Console.WriteLine("Third case");
                    break;                
            }
        }
        
        static bool Log(string message, bool result)
        {
            Console.WriteLine(message);
            return result;
        }
    }
