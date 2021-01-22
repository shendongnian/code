    class ForEachVsClass
    {
    static Int32 Iterations = 1000000000;
    static int Work = 0;
    public static void Init(string[] args)
    {
        if (args.Length > 0)
            Iterations = Int32.Parse(args[0]);
        Console.WriteLine("Iterations: " + Iterations);
    }
    static List<Fruit> ListOfFruit = new List<Fruit> { 
        new Fruit("Apple",1), new Fruit("Orange",2), new Fruit("Kiwi",3), new Fruit("Banana",4) };
    internal class Fruit {
        public string Name { get; set; }
        public int Value { get; set; }
        public Fruit(string _Name, int _Value) { Name = _Name; Value = _Value; }
    }
    [Benchmark]
    public static void NativeForLoop()
    {
        for (int x = 0; x < Iterations; x++)
        {
            NativeForLoopWork();
        }
    }
    public static void NativeForLoopWork()
    {
        foreach (Fruit CurrentFruit in ListOfFruit) {
            Work+=CurrentFruit.Value;
        }
    }
    [Benchmark]
    public static void ListDotForEach()
    {
        for (int x = 0; x < Iterations; x++)
        {
            ListDotForEachWork();
        }
    }
    public static void ListDotForEachWork()
    {
        ListOfFruit.ForEach((f)=>Work+=f.Value);
    }
