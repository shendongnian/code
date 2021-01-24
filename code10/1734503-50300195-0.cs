    static void Main(string[] args)
    {
        Microsoft.VisualBasic.Collection c = new Microsoft.VisualBasic.Collection();
        c.Add(new { Id = 1, Name = "John"});
        c.Add(new { Id = 2, Name = "Mary" });
        DoSomething(c);
        Console.ReadLine();
    }
    public static void DoSomething(ICollection collection)
    {
        foreach (dynamic v in collection)
        {
            Console.WriteLine($"{v.Id} - {v.Name}");
        }
    }
