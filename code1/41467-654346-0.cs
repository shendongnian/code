    class Foo {
        public int Value { get; set; }
    }
    class Bar {
        public int Value { get; set; }
    }
    static class Program {
        static void Main() {
            Expression<Func<Foo, bool>> predicate =
                x => x.Value % 2 == 0;
            Expression<Func<Bar, Foo>> convert =
                bar => new Foo { Value = bar.Value };
    
            var param = Expression.Parameter(typeof(Bar), "bar");
            var body = Expression.Invoke(predicate,
                  Expression.Invoke(convert, param));
            var lambda = Expression.Lambda<Func<Bar, bool>>(body, param);
    
            // test with LINQ-to-Objects for simplicity
            var func = lambda.Compile();
            bool withOdd = func(new Bar { Value = 7 }),
                 withEven = func(new Bar { Value = 12 });
        }
    }
