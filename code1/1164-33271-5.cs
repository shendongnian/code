    static void Main(string[] args)
    {
        var getRandomObjectX = TypeCurry(GetRandomObject,
            new { Name = default(string), Badges = default(int) });
        do {
            var obj = getRandomObjectX();
            Console.WriteLine("Name : {0} Badges : {1}",
                obj.Name,
                obj.Badges);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
    static Random r = new Random();
    static object GetRandomObject()
    {
        return new {
            Name = Guid.NewGuid().ToString().Substring(0, 4),
            Badges = r.Next(0, 100)
        };
    }
    
