	public class LogCollectorTarget : TargetWithLayout, ILogCollector
	{
		private readonly ConcurrentQueue<string> _logMessageBuffer;
		public LogCollectorTarget()
		{
			_logMessageBuffer = new ConcurrentQueue<string>();
		}
		protected override void Write(LogEventInfo logEvent)
		{
			var logMessage = Layout.Render(logEvent);
			_logMessageBuffer.Enqueue(logMessage);
		}
		public string GetBuffer()
		{
			// How many messages should we dequeue?
			var count = _logMessageBuffer.Count;
			
			var messages = new StringBuilder();
			
			while (count > 0 && _logMessageBuffer.TryDequeue(out var message))
			{	
				messages.AppendLine(message);	
				count--;
			}		
			
			return messages.ToString();
		}
	}
