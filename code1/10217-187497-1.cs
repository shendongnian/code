    using System;
    using System.Linq;
    using System.Linq.Expressions;
    namespace ExpressionTreeThingy
    {
        class Program
        {
            static void Main(string[] args)
            {
                Expression<Func<int, int>> expr = (x) => x + 1; //this is not a delegate, but an object
                var del = expr.Compile(); //compiles the object to a CLR delegate, at runtime
                Console.WriteLine(del(5)); //we are just invoking a delegate at this point
                Console.ReadKey();
            }
        }
    }
