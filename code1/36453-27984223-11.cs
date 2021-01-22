	var channelFactory = new ChannelFactory<IMyService>("");
	var serviceHelper = new ServiceHelper<IMyService>(channelFactory);
	var proxy = serviceHelper.CreateChannel();
	using (proxy as IDisposable)
	{
	    proxy.DoWork();
	}
