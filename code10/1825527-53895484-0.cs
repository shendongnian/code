	[EventSource(Name = "Samples-EventSourceDemos-EventLog")]
	public sealed class MinimalEventSource : EventSource
	{
		public static MinimalEventSource Log = new MinimalEventSource();
		[Event(601, Channel = EventChannel.Admin,  Message = "Unhandled exception occurred. Details: {0}", Keywords = EventKeywords.None, Level = EventLevel.Critical)]
		private void UnhandledException(string exceptionMsg)
		{
			this.IsEnabled().Dump();
			this.WriteEvent(601, exceptionMsg);
		}
	}
