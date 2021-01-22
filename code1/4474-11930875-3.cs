		Dictionary<string, float> foo = new Dictionary<string, float>();
		foo.Add("Item 25% 1", 0.5f);
		foo.Add("Item 25% 2", 0.5f);
		foo.Add("Item 50%", 1f);
		
		for(int i = 0; i < 10; i++)
		    Console.WriteLine(this, "Item Chosen {0}", foo.RandomElementByWeight(e => e.Value));
    
