	public object GetConversation(ConversationSource source, string parameter)
	{
	    switch (source)
		{
			case ConversationSource.Id :
		        // Get by id
				break;
			case ConversationSource.Address :
		        // Get by address
				break;			
		}
		return null;
	}
	
	public enum ConversationSource
	{
		Id,
		Address,
	}
