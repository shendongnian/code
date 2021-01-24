	class Train
	{
		protected Train() { }
		protected static Train instance;
		public static Train GetSingeltonInstance()
		{
			if(instance == null)
			{
				instance = new Train();
			}
			return instance;
		}
	}
	class TainUser
	{
		private readonly Train train;
		public TainUser()
		{
			train = Train.GetSingeltonInstance();
		}
	}
