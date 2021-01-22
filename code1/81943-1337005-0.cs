	class Chicken
	{
		public string attribute { get; set; }
	}
	
	class Duck
	{
		public string attribute { get; set; }
	}
	
	interface IHasAttribute
	{
		string attribute { get; set; }
	}
	
	class ChickenWrapper : IHasAttribute
	{
		private Chicken chick = null;
		public string attribute
		{
			get { return chick.attribute; }
			set { chick.attribute = value; }
		}
		public ChickenWrapper(object chick)
		{
			this.chick = chick as Chicken;
		}
	}
	
	class DuckWrapper : IHasAttribute
	{
		private Duck duck = null;
		public string attribute
		{
			get { return duck.attribute; }
			set { duck.attribute = value; }
		}
		public DuckWrapper(object duck)
		{
			this.duck = duck as Duck;
		}
	}
	
	void SetAttribute<T>(T x, string value) where T : IHasAttribute
	{
		try
		{
			x.attribute = value;
		}
		catch
		{
			// handle...
		}
	}
