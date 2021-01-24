    static void Main(string[] args)
    {
        Filters filter1 = new Filters();
    
        foreach (var prop in filter1.GetType().GetProperties())
        {
            Console.WriteLine("{0}={1}", prop.Name, (int)prop.GetValue(filter1, null) + filter1.GetType().GetProperties().Length);
        }
            
        Console.ReadKey();
    }
