    List<string> ItemList = new List<string>();
    Console.WriteLine("Items Added To Inventory Are: "); // Outputs List in reverse order. (Recent input first).
    for (int i = 0; i < 10; i++) // Continue For Loop until i is < the needed amount.
    {
        Console.WriteLine($"{i+1}: Enter Item Name To Add To Inventory"); // Asks for user input into array.
        var ListInput = Console.ReadLine(); // User inputs value into field.
        ItemList.Add(ListInput);
    }
