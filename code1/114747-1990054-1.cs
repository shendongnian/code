    static class Program
    {
        static void Main()
        {
            Foo foo = Foo.Get(2), clone;
            DataContractSerializer ser = new DataContractSerializer(typeof(Foo));
            using (MemoryStream ms = new MemoryStream())
            {
                ser.WriteObject(ms, foo);
                ms.Position = 0;
                clone = (Foo)ser.ReadObject(ms);
            }
            Console.WriteLine(ReferenceEquals(foo, clone)); // true
        }
    }
