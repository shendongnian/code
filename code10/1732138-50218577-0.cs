    public class EventNotification { }
	
	public class SingletonThing
	{
        //don't need async for Rx
		public void SendEventsAsync(IEnumerable<EventNotification> events)
 		{
			foreach (var element in events)
			{
			}
		}
	}
