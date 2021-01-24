    private static void Main()
    {
        var items = new List<Item>();
        // Populate the list of items using our method to continually get the next item
        for (int i = 0; i < 4; i++)
        {
            items.Add(GetNextItem(items));
        }
        // Now output the items to the Console window
        foreach (var item in items)
        {
            Console.WriteLine($"{item.PrimaryId} {item.SecondaryId}");
        }
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
