    private static void Main()
    {
        var linkedList = new LinkedList();
        for (int i = 0; i < 10; i++)
        {
            linkedList.Add($"Item #{i + 1}");
        }
        linkedList.WriteNodes();
        var dash = new string('-', 25);
        Console.WriteLine($"{dash}\nCalling: RemoveAfterIndex(3)\n{dash}");
        linkedList.RemoveAfterIndex(3);
        linkedList.WriteNodes();
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
