    static async Task Main(string[] args)
    {
  	//Find eggs and bacon in database
    Task<List<Egg>> eggTask = FindEggsAsync(2);
    Task<List<Bacon>> baconTask = FindBaconAsync(3);
	Coffee cup = PourCoffee();
    Console.WriteLine("coffee is ready");
	
    Juice oj = PourOJ();
    Console.WriteLine("oj is ready");
    
    List<Egg> eggs = await eggTask;
    List<Bacon> bacon = await baconTask;
    
    FryEggs(eggs);
    Console.WriteLine("eggs are ready");
    FryBacon(bacon);
    Console.WriteLine("bacon is ready");
    
    Console.WriteLine("Breakfast is ready!");
    }
