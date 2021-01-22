    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    class FooUgly
    {
        public int IdThis { get; set; }
        public int IdThat { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
    }
    class Foo
    {
        public int IdThis { get; set; }
        public int IdThat { get; set; }
        public double[] Values { get; set; }
        public Foo() { }
        internal Foo(FooUgly ugly)
        {
            IdThis = ugly.IdThis;
            IdThat = ugly.IdThat;
            Values = extractor.Extract(ugly);
        }
        // re-use this!!!
        static readonly ValueExtractor<FooUgly, double> extractor
            = new ValueExtractor<FooUgly, double>("Value", 1, 3);
    }
    static class Program
    {
        static void Main()
        {
            FooUgly ugly = new FooUgly { IdThis = 1, IdThat = 2, Value1 = 3, Value2 = 4, Value3 = 5 };
            Foo foo = new Foo(ugly);
        }
    }
    class ValueExtractor<TFrom,TValue>
    {
        private readonly Func<TFrom, TValue[]> func;
        public TValue[] Extract(TFrom source)
        {
            return func(source);
        }
        public ValueExtractor(string memberPrefix, int start, int end)
        {
            if(end < start) throw new ArgumentOutOfRangeException();
            ParameterExpression param = Expression.Parameter(typeof(TFrom), "source");
            List<Expression> vals = new List<Expression>();
            for(int i = start ; i <= end ; i++) {
                vals.Add(Expression.PropertyOrField(param, memberPrefix + i));
            }
            Expression arr = Expression.NewArrayInit(typeof(TValue), vals);
            func = Expression.Lambda<Func<TFrom, TValue[]>>(arr, param).Compile();
        }
    }
