    using System;
    
    class Program {
        static void Main(string[] args) {
            string[] dates = new string[] { "01:02:03", "1:02:03", "1:2:03", "1:02:3", "01:2:3", "1:2:3" };
            foreach (string date in dates) {
                DateTime dt = DateTime.ParseExact(date, "H:m:s", null);
                Console.WriteLine(dt);
            }
            Console.ReadLine();
        }
    }
