    class Program
    {
        static void Main()
        {
            Console.WriteLine(Serializer.GetProto<Foo>());
        }
    }
    [ProtoContract]
    public class Foo
    {
        [ProtoMember(1)]
        public List<Bar> Items { get; set; }
    }
    [ProtoContract]
    public class Bar { }
