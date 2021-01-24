    private static void Main()
    {
        var linkedList = new LinkedList();
        for (int i = 0; i < 10; i++)
        {
            linkedList.Add($"Item #{i + 1}");
        }
        linkedList.WriteNodes();
        Console.WriteLine("--------------");
        linkedList.RemoveAfter(3);
        linkedList.WriteNodes();
        Console.WriteLine("--------------");
    }
