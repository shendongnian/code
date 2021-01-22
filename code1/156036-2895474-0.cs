        [TestFixture]
    public class WcfPerSessionLifestyleManagerTests
    {
    	private const string SvcUrl = "http://localhost:8732/Design_Time_Addresses/JulaAil.DataService.WcfService/AilDataService/";
    
    	private TypeResolverServiceHost _serviceHost;
    	private ChannelFactory<IAilDataService> _factory;
    	private IAilDataService _channel;
    	private WindsorContainer _container;
    
    	[Test]
    	public void Can_Populate_OperationContext_Using_OperationContextScope()
    	{
    		using (new OperationContextScope((IContextChannel) _channel))
    		{
    			Assert.That(OperationContext.Current, Is.Not.Null);
    		}
    	}
    }
