    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    class Foo
    {
        public Foo() { Bar = new Bar(); }
        public Bar Bar { get; private set; }
    }
    class Bar
    {
        public string Name {get;set;}
    }
    static class Program
    {
        static void Main()
        {
            Foo foo = new Foo();
            var setValue = BuildSet<Foo, string>("Bar.Name");
            var getValue = BuildGet<Foo, string>("Bar.Name");
            setValue(foo, "abc");
            Console.WriteLine(getValue(foo));        
        }
        static Action<T, TValue> BuildSet<T, TValue>(string property)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            ParameterExpression valArg = Expression.Parameter(typeof(TValue), "val");
            Expression expr = arg;
            foreach (string prop in props.Take(props.Length - 1))
            {
                // use reflection (not ComponentModel) to mirror LINQ 
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            // final property set...
            PropertyInfo finalProp = type.GetProperty(props.Last());
            MethodInfo setter = finalProp.GetSetMethod();
            expr = Expression.Call(expr, setter, valArg);
            return Expression.Lambda<Action<T, TValue>>(expr, arg, valArg).Compile();        
    
        }
        static Func<T,TValue> BuildGet<T, TValue>(string property)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ 
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            return Expression.Lambda<Func<T, TValue>>(expr, arg).Compile();
        }
    }
