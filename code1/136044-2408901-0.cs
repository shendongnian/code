    [XmlType]
    public class Foo
    {
        [XmlElement(Order=1)]
        public int? Value { get; set; }
    }
    [XmlType]
    public class Bar
    {
        [XmlElement(Order = 1)]
        public int Value { get; set; }
        [XmlIgnore]
        public bool ValueSpecified { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            Foo foo = new Foo { Value = 123 };
            Bar bar = Serializer.ChangeType<Foo, Bar>(foo);
            Console.WriteLine("{0}, {1}", bar.Value, bar.ValueSpecified);
    
            foo = new Foo { Value = null };
            bar = Serializer.ChangeType<Foo, Bar>(foo);
            Console.WriteLine("{0}, {1}", bar.Value, bar.ValueSpecified);
    
            bar = new Bar { Value = 123, ValueSpecified = true };
            foo = Serializer.ChangeType<Bar, Foo>(bar);
            Console.WriteLine(foo.Value);
    
            bar = new Bar { Value = 123, ValueSpecified = false };
            foo = Serializer.ChangeType<Bar, Foo>(bar);
            Console.WriteLine(foo.Value);
        }
    }
