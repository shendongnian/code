    class Observer
    {
    	public Observer(Publisher pub)
    	{
    		pub.Add(this);
    	}
    	
    	public Alert()
    	{
    		System.Console.WriteLine("Oh no, stuff is happening!");
    	}
    }
