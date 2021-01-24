	public class Portfolio
	{
		public string Id { get; set; }
	}
	public class Entity
	{
		public string Id { get; set; }
	}
    public class Creator // use one class instead of three? it depends on their meaning
    {
        public string Id { get; set; }
    }
	public class ExampleEvent 
	{
        private ExampleEvent() // for JSON deserializer
        {
            Creator = new Creator();
            Portfolio = new Portfolio();
            Entity = new Entity();
        }
		[JsonIgnore]
		public Creator Creator { get; set; } 
		public string CreatorId
		{
			get => Creator.Id;
			set => Creator.Id = value;
		}
		[JsonIgnore]
		public Portfolio Portfolio { get; set; } 
		public string PortfolioId
		{
			get => Portfolio.Id;
			set => Portfolio.Id = value;
		}
		[JsonIgnore]
		public Entity Entity { get; set; } 
		public string EntityId
		{
			get => Entity.Id;
			set => Entity.Id = value;
		}
        public int EventVersion { get; set; }
        public string Id { get; set; }
 
        public string CorrelationId { get; set; }
	}
