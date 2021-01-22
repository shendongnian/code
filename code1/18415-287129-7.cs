    namespace MyNamespace {
        partial class MyDataContext
        {
            public int Foo(int? inc, string dataSet)
            {
                return FooPrivate(inc, dataSet).Single().value;
            }
        }
    }
