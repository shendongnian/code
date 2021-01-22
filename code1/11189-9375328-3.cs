class Program
{
    static MyCollection<string> strings = new MyCollection<string>();
    static void Main(string[] args)
    {
        new Thread(adder).Start();
        Thread.Sleep(15);
        dump();
        Thread.Sleep(125);
        dump();
        Console.WriteLine("Press any key.");
        Console.ReadKey(true);
    }
        
    static void dump()
    {
        Console.WriteLine(string.Format("Count={0}", strings.Count).PadLeft(40, '-'));
        using (var enumerable = strings.GetIteratorWrapper())
        {
            foreach (var s in enumerable)
                Console.WriteLine(s);
        }
        Console.WriteLine("".PadLeft(40, '-'));
    }
    static void adder()
    {
        for (int i = 0; i < 100; i++)
        {
            strings.Add(Guid.NewGuid().ToString("N"));
            Thread.Sleep(7);
        }
    }
}
