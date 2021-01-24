    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    
    delegate string ByRefFunc<T>(ref T val);
    struct X
    {
        public X(string name) => Name = name;
        public string Name { get; }
    }
    static class P
    {
        static void Main()
        {
            var p = Expression.Parameter(typeof(X).MakeByRefType(), "p");
            var lambda = Expression.Lambda<ByRefFunc<X>>(
                Expression.Property(p, "Name"), p);
            X x = new X("abc");
            var s = lambda.Compile()(ref x);
            Console.WriteLine(s);       
        }
    }
