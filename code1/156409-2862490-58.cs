    public class Foo
    {
        //various normal properties and methods go here
        public static Foo FooFactory(IDataRecord record)
        {
            return new Foo
            {
                Property1 = record[0],
                Property2 = record[1]
                //...
            };
        }
    }
