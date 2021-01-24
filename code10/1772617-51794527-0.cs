    [MessagePackObject]
    public class Msg
    {
        [Key(0)]
        public List<double> data;
        [Key(1)]
        public List<int> shape;
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var bytes = MessagePackSerializer.Serialize(new Msg()
            {
                data = new List<double> { 1.23, 3.01, 44.02, 33 },
                shape = new List<int>() { 2, 2 }
            });
            var msg = MessagePackSerializer.Deserialize<Msg>(bytes);
            Console.WriteLine(MessagePackSerializer.ToJson(msg));
        }
    }
