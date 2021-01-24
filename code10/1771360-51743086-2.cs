	public class PortfolioId
	{
		public string Id { get; set; }
	}
	public class EntityId
	{
		public string Id { get; set; }
	}
    public class UserId
    {
        public string Id { get; set; }
    }
	public class ExampleEvent 
	{
        private ExampleEvent() // for JSON deserializer
        {
            Creator = new UserId();
            Portfolio = new PortfolioId();
            Entity = new EntityId();
        }
        // add your base constructor call
        public ExampleEvent(PortfolioId portfolio, EntityId entity, UserId creator)
        {
            Creator = creator;
            Portfolio = portfolio;
            Entity = entity;
        }
		[JsonIgnore]
		public UserId Creator { get; set; } 
		public string CreatorId
		{
			get => Creator.Id;
			set => Creator.Id = value;
		}
		[JsonIgnore]
		public PortfolioId Portfolio { get; set; } 
		public string PortfolioId
		{
			get => Portfolio.Id;
			set => Portfolio.Id = value;
		}
		[JsonIgnore]
		public EntityId Entity { get; set; } 
		public string EntityId
		{
			get => Entity.Id;
			set => Entity.Id = value;
		}
        public int EventVersion { get; set; }
        public string Id { get; set; }
 
        public string CorrelationId { get; set; }
	}
