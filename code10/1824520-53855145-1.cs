    void Main()
    {
    	var g = new Generator<int>();
    	var ongoingItems = g.Items;
    	var allItems = g.Items.Replay().RefCount();
    	
    	using(var tempSubscriber = allItems.Subscribe())
    	{
    		g.Push(1);
    		g.Push(2);
    
    		ongoingItems.Subscribe(x => Console.WriteLine($"Ongoing: got {x}"));
    		allItems.Subscribe(x => Console.WriteLine($"WithHistory: got {x}"));
    
    		g.Push(3);
    		g.Push(4);
    		g.Push(5);
    
    		Console.ReadLine();
    	}
    }
