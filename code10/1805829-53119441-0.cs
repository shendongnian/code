	public class Endpoint : AggregateRoot<Endpoint, EndpointId>
	{
		public Endpoint(EndpointId id) : base(id){}
		public string Code { get; private set; }
		public void Initialize(string code, string source)
		{
			Emit(new EndpointInitializedEvent(code,source));
		}
		public void Apply(EndpointInitializedEvent evt)
		{
			Code = evt.Code;
		}
	}
	
	public class EndpointByCodeLocator : IReadModelLocator
	{
		public IEnumerable<string> GetReadModelIds(IDomainEvent evt)
		{
			var endpointInitializedEvent = evt as IDomainEvent<Endpoint, EndpointId, EndpointInitializedEvent>;
			if (endpointInitializedEvent == null)
				yield break;
			else
				yield return endpointInitializedEvent.AggregateEvent.Code;
		}
	}
