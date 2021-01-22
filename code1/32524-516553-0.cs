    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    static class Program
    {
        class Foo
        {
            public int Value { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        class Bar : Foo {}
        static void Main()
        {
            List<Foo> foos = new List<Foo>();
            for (int i = 0; i < 10; i++) foos.Add(new Foo { Value = i });
    
            List<Bar> bars = foos.ConvertAll<Bar>(Clone<Foo, Bar>);
        }
        public static TTo Clone<TFrom, TTo>(this TFrom obj) where TTo : TFrom, new()
        {
            return ObjectExtCache<TFrom, TTo>.Convert(obj);
        }
        static class ObjectExtCache<TFrom, TTo> where TTo : TFrom, new()
        {
            private static readonly Func<TFrom, TTo> converter;
            static ObjectExtCache()
            {
                ParameterExpression param = Expression.Parameter(typeof(TFrom), "in");
                var bindings = from prop in typeof(TFrom).GetProperties()
                               where prop.CanRead && prop.CanWrite
                               select (MemberBinding)Expression.Bind(prop,
                                   Expression.Property(param, prop));
                converter = Expression.Lambda<Func<TFrom, TTo>>(
                    Expression.MemberInit(
                        Expression.New(typeof(TTo)), bindings), param).Compile();
            }
            public static TTo Convert(TFrom obj)
            {
                return converter(obj);
            }
        }
    }
