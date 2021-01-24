    static void Main(string[] args)
    {
        var officers = new List<Officer>
        {
            new Officer { Name = "Officer Foo" },
            new Officer { Name = "Officer Bar" }
        };
        var workers = new List<Worker>
        {
            new Worker { Name = "Worker Foo" },
            new Worker { Name = "Worker Bar" }
        };
        var people = workers.Cast<IPerson>().Concat(officers);
        var filteredPeople = Program.Filter(people, "Foo");
        Console.ReadKey(true);
    }
    static IEnumerable<IPerson> Filter(IEnumerable<IPerson> people, string keyword)
    {
        return people.Where(p => p.Name.Contains(keyword));
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Officer : IPerson
    {
        public string Name { get; set; }
    }
    class Worker : IPerson
    {
        public string Name { get; set; }
    }
