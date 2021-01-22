    using System;
    
    class Program {
        static void Main(string[] args) {
            var s = "2009/01/10 17:18:44 -0800";
            var dto = DateTimeOffset.ParseExact(s, "yyyy/MM/dd HH:mm:ss zzzz", null);
            var utc = dto.UtcDateTime;
            Console.WriteLine(utc);
            Console.ReadLine();
        }
    }
