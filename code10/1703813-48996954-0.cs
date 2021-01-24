	public static Guid? GetMessageId<T>(ConsumeContext<T> input) where T : class
	{
		var casted = input as ConsumeContext<IMessage>;
		if (casted == null) return null;
		return casted.Message.MessageId;
	}
