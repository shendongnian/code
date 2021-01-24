    using (((WindowsIdentity)User.Identity).Impersonate())
    {
    	var channelFactory = new ChannelFactory<IService1>("*");
    
    	var proxy = channelFactory.CreateChannel();
    
    	return View((object)proxy.GetName("1"));
    }
