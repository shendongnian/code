    IocManager.IocContainer.Register(
    	Component.For<MySessionWebApi>().LifestylePerWebRequest(), Component.For<MySessionMvc>().LifestylePerWebRequest(),
    	Component.For<IMySession>().UsingFactoryMethod((k, c) => this.MySessionFactory(k)).LifestylePerWebRequest().IsDefault());
    
    	
     private IMySession MySessionFactory(IKernel kernel)
    {
    		if (System.Web.HttpContext.Current.Request == null)
    		{
    			return (IMySession)kernel.Resolve<MySessionMvc>();	
    
    		}
    		if (System.Web.HttpContext.Current.Request.Path.Contains("/api/"))
    		{
    			return (IMySession)kernel.Resolve<MySessionWebApi>();
    		}
    		else
    		{
    			return (IMySession)kernel.Resolve<MySessionMvc>();
    		} 
    }
    	
