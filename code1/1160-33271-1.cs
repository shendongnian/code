    static void Main(string[] args)
    {
        var getRandomObjectX = TypeCurry(GetRandomObject,
            new { ObjID = default(string) });
        do {
            Console.WriteLine(getRandomObjectX().ObjID);
            Console.WriteLine(getRandomObjectX().ObjID);
            Console.WriteLine(getRandomObjectX().ObjID);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
    static object GetRandomObject()
    {
        return new { ObjID = Guid.NewGuid().ToString() };
    }
    
