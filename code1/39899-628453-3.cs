    for (int i = 0; i < 5; i++)
    {
      //Get input from user
      System.Console.WriteLine("Please Sir Enter the stock number");
      stockNum= Convert.ToInt32(Console.ReadLine()); //This isn't very safe...
      System.Console.WriteLine("Please Sir Enter the price");
      price = Convert.ToInt32(Console.ReadLine()); //This isn't very safe...
      System.Console.WriteLine("Please Sir Enter the item name");
      name = Console.ReadLine();
      //Then add it to a new object
      Widget item = new Widget(stockNum, price, name);
    
      //And add this item to a list
      items.Add(item);
    }
