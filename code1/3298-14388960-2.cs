    public class Simple : DefaultValueInitializer
    {
        [Instance("StringValue")]
        public string StringValue { get; set; }
        [Instance]
        public List<string> Items { get; set; }
        [Instance(true, 3,4)]
        public Point Point { get; set; }
    }
    public static void Main(string[] args)
    {
        var obj = new Delivered
            {
                Items = {"Item1"}
            };
        Console.WriteLine(obj.Items[0]);
        Console.WriteLine(obj.Point);
        Console.WriteLine(obj.StringValue);
    }
