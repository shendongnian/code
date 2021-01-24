    string[,] items = new string[2, 3];
    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine("Enter Item Name:");
        items[i, 0] = Console.ReadLine();
        Console.WriteLine("Enter Item Price:");
        items[i, 1] = Console.ReadLine();
        Console.WriteLine("Enter Item Quantity:");
        items[i, 2] = Console.ReadLine();
    }
    for (int i = 0; i < 2; i++)
    {
      Console.WriteLine("Item Name: "+items[i,0]);
      Console.WriteLine("Item Price: " + items[i, 1]);
      Console.WriteLine("Item Quantity: " + items[i, 2]);
    }
    Console.ReadLine();
