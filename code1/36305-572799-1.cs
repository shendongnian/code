    using System;
    using System.Linq.Expressions;
    static class Program
    {
        static void Main()
        {
            var args = Expression.Parameter(typeof(float[]), "args");
            var x = Expression.ArrayIndex(args, Expression.Constant(0));
            var y = Expression.ArrayIndex(args, Expression.Constant(1));
            var add = Expression.Add(x, y);
            var lambda = Expression.Lambda<Func<float[], float>>(add, args);
            
            Func<float[], float> func = lambda.Compile();
            Console.WriteLine(func.Call(1, 2));
            Console.WriteLine(func.Call(3, 4));
            Console.WriteLine(func.Call(5, 6));
        }
    
        static T Call<T>(this Func<T[], T> func, params T[] args)
        { // just allows "params" usage...
            return func(args);
        } 
    }
