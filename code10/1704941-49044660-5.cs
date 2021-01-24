    private static void Main()
    {
        List<MileStone> items = new List<MileStone>
        {
            new MileStone {CheckPoint = 0, Distance = 15.4M},
            new MileStone {CheckPoint = 20, Distance = 24.8M},
            new MileStone {CheckPoint = 40, Distance = 39.7M},
            new MileStone {CheckPoint = 60, Distance = 59.3M},
            new MileStone {CheckPoint = 80, Distance = 80.1M}
        };
        Console.WriteLine("Neighbors of 45: {0}",
            string.Join(", ", GetNeighboringItems(45, items)));
        Console.WriteLine("Neighbors of 10: {0}",
            string.Join(", ", GetNeighboringItems(10, items)));
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
