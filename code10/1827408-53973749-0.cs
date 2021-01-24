    delegate void Iterator();
    
    static void Main(string[] args)
    {
        List<Iterator> iterators = new List<Iterator>();
        for (int i = 0; i < 15; i++)
        {
            int copy = i;
            iterators.Add(delegate { Console.WriteLine(copy); });
        }
    
        foreach (var iterator in iterators)
        {
            iterator();
        }
    
        Console.Read();
    }
