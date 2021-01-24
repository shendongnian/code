	public class RootObject
	{
		static int CalculateDefaultEventsPerProcessor()
		{
			// Replace with calculated value
			return 12;
		}
		
		public RootObject()
		{
			EventsPerProcessor = CalculateDefaultEventsPerProcessor();
		}
		
		[JsonProperty]
		public int EventsPerProcessor { get; protected set; }
	}
