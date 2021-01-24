	public class Country
	{
		public string Name { get; set; }
	}
	public class Countries : List<Country>
	{
		public Countries(IEnumerable<Country> initializationData) : base(initializationData)
		{
            //No body. Work is done by base class constructor.
		}
	}
