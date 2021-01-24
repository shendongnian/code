	public class Functions 
	{
		public static void ProcessQueueMessage([QueueTrigger(QueueName)] string serializedMessage)
		{
			var message = DeserializeMessage(serializedMessage);
			MessageProcesor.ProcessMessage(message);
		}
	}
