    private static void Main()
    {
        var records = new List<Record>
        {
            new Record {ID = 3, Name = "Apple", ChildID = 6},
            new Record {ID = 54, Name = "Orange", ChildID = 3},
            new Record {ID = 6, Name = "Banana", ChildID = null}
        };
        var sortedRecords = OrderRecords(records);
        Console.WriteLine(string.Join(", ", sortedRecords.Select(r => r.Name)));
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
