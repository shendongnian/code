    using System;
    using System.Linq;
    [My(15)]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            var ats =
                from a in typeof(Program).GetCustomAttributes(typeof(MyAttribute), true)
                let a2 = a as MyAttribute
                where a2 != null
                select a2;
                
            foreach(var a in ats)
                Console.WriteLine(a.Value);
            Console.WriteLine("Program ended");
            Console.ReadLine();
        }
    }
