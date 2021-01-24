    var item = new ItemList
    {
        Name = "Assassin's Creed"
    };
    List<ItemList> items = new List<ItemList>
    {
        item,
        item
    };
        
    var serialized = JsonConvert.SerializeObject(items);
    List<ItemList> games = JsonConvert.DeserializeObject<List<ItemList>>(serialized);
    // Incorrect output
    Console.WriteLine(games);
    // Correct output
    foreach(ItemList game in games)
    {
        Console.WriteLine(game.Name);
    }
    Console.ReadLine();
