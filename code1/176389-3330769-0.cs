    using System;
    using System.Linq.Expressions;
    
    class Test
    {
        static void Main()
        {
            Expression<Func<DateTime, int>> dt = p => p.Minute;
            Console.WriteLine(dt);
        }
    }
