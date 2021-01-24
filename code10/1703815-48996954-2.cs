		public static void Main()
		{
			var exampleObject = new MyClass<SpecificMessage>();
			exampleObject.Message = new SpecificMessage { MessageId = new Guid("00000001-0002-0003-0004-000000000005") };
			
			var messageId = GetMessageId(exampleObject);
			Console.WriteLine(messageId.Value);
		}
