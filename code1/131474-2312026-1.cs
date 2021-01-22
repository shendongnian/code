	public IFlyerExtensions
	{
		
		public void OnReadyToFly(this IFlyer flyer) 
		{
		    FlyBehavior.Fly(); 
		}
		public void OnReadyToLand(this IFlyer flyer) 
		{
		    FlyBehavior.Land(); 
		}
	}
