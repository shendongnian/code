    [ProtoContract]
    public class Data1
    {
        [ProtoMember(1, IsRequired=true)]
        public int A { get; set; }
    }
    [ProtoContract]
    public class Data2
    {
        [ProtoMember(1, IsRequired = true)]
        public string B { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Data1 { A = 1};
            var d2 = new Data2 { B = "Hello" };
            var ms = new MemoryStream();
            Serializer.Serialize(ms, d1); 
            Serializer.Serialize(ms, d2);
            ms.Position = 0;
            var d3 = Serializer.Deserialize<Data1>(ms); // This will fail
            var d4 = Serializer.Deserialize<Data2>(ms);
            Console.WriteLine("{0} {1}", d3, d4);
        }
    }
