    using System;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DBNull dbNull = DBNull.Value;
                Console.WriteLine(typeof(string).IsAssignableFrom(typeof(DBNull)));//False
                Console.WriteLine(dbNull is string); //False
                //Console.WriteLine((string)dbNull);  // compile time error
                //Console.WriteLine(dbNull as string); // compile time error
                Console.ReadLine();
            }
        }
    }
