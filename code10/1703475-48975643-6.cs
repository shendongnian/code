	public static void Main()
	{
		var p = new Program();
		p.DoSomething(new Car());
		p.DoSomething(new Bike());
	}
	public void DoSomething(Vehicle v)
	{
		v.PrintRouteStatus();
	}
