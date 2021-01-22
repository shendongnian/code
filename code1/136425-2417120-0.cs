    using System;
    using System.Runtime.Serialization;
    [DataContract]
    class Foo
    {
        [DataMember]
        public Bar Bar { get; set; }
    }
    [DataContract]
    class Bar
    {
        [DataMember]
        public Foo Foo { get; set; }
    }
    static class Program
    {
        public static T Clone<T>(T obj) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T), null, int.MaxValue, false, true, null);
            using (var ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                return (T)serializer.ReadObject(ms);
            }
        }
        static void Main()
        {
            Foo foo = new Foo();
            Bar bar = new Bar();
            foo.Bar = bar;
            bar.Foo = foo; // nice cyclic graph
    
            Foo clone = Clone(foo);
            Console.WriteLine(foo != clone); //true - new object
            Console.WriteLine(foo.Bar.Foo == foo); // true; copied graph
    
        }
    }
