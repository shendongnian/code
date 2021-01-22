    Channel channel;
    Authentication authentication;
    
    if (entities == null)
    {
    	using (entities = Entities.GetEntities())
    	{
    		channel = entities.GetChannelById(googleShoppingChannelCredential.ChannelId);
    		[...]
    	}
    }
    else
    {
    	channel = entities.GetChannelById(googleShoppingChannelCredential.ChannelId);
    	[...]
    }
