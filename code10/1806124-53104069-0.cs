    using System;
    
    class Test
    {
        static void Main()
        {
            var test = new DateTimeOffset(new DateTime(2018, 10, 26, 20, 0, 0));
            var test2 = test.AddHours(48);
            var test3 = test.ToUniversalTime().AddHours(48).ToLocalTime();
            Console.WriteLine(test2);
            Console.WriteLine(test3);
        }
    }
