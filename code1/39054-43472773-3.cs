    var jan = new Person("Jan");
    
    jan.Age = 24; // regular property of the person object;
    jan.DynamicProperties().NumberOfDrinkingBuddies = 27; // not originally scoped to the person object;
    
    if (jan.Age < jan.DynamicProperties().NumberOfDrinkingBuddies)
	{
        Console.WriteLine("Jan drinks too much");
	}
