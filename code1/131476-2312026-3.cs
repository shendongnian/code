	public IFlyerExtensions
	{
		
		public void OnReadyToFly(this IFlyer flyer) 
		{
		    flyer.FlyBehavior.Fly(); 
		}
		public void OnReadyToLand(this IFlyer flyer) 
		{
		    flyer.FlyBehavior.Land(); 
		}
	}
