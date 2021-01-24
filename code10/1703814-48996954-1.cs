	public class Program
	{
		public static Guid? GetMessageId<T>(ConsumeContext<T> input) where T : class
		{
			var casted = input as ConsumeContext<IMessage>;
			if (casted == null) return null;
			return casted.Message.MessageId;
		}
		public static void Main()
		{
			var exampleObject = new MyClass<Message>();
			exampleObject.Message = new Message { MessageId = new Guid("00000001-0002-0003-0004-000000000005") };
			
			var messageId = GetMessageId(exampleObject);
			Console.WriteLine(messageId.Value);
		}
	}
