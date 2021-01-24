    Func<IKernel, CreationContext, IContent> factoryMethod = (k, cc) =>
    {
    	var requestedType = cc.RequestedType; // e.g. typeof(PostContent)
    	var contentAppService =  new ContentAppService(); 
    	var method = typeof(ContentAppService).GetMethod("GetContent")
    		.MakeGenericMethod(requestedType);
    	IContent result = (IContent)method
    		.Invoke(contentAppService, null); // invoking GetContent<> via reflection
    	return result;
    };
    
    var container = new WindsorContainer(); 
    container.Register( // registration
    	Classes.FromThisAssembly()// selection an assembly
    	.BasedOn<IContent>() // filtering types to register
    	.Configure(r => r.UsingFactoryMethod(factoryMethod)) // using factoryMethod
    	.LifestyleTransient());
    
    var postContent = container.Resolve<PostContent>(); // requesting PostContent
