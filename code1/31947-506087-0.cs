    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    
    namespace StockServer
    {
    	public class StockServiceHost : ServiceHost
    	{
    		public StockServiceHost(object singletonInstance, params Uri[] baseAddresses)
    			: base(singletonInstance, baseAddresses)
    		{
    		}
    
    		public StockServiceHost(Type serviceType, params Uri[] baseAddresses)
    			: base(serviceType, baseAddresses)
    		{
    		}
    
    		protected override void InitializeRuntime()
    		{
    			this.AddServiceEndpoint(
    				typeof(IPolicyProvider),
    				new WebHttpBinding(),
    				new Uri("http://localhost:10201/")).Behaviors.Add(new WebHttpBehavior());
    
    			this.AddServiceEndpoint(
    				typeof(IStockService),
    				new PollingDuplexHttpBinding(),
    				new Uri("http://localhost:10201/SilverlightStockService"));
    
    			this.AddServiceEndpoint(
    				typeof(IStockService),
    				new WSDualHttpBinding(WSDualHttpSecurityMode.None),
    				new Uri("http://localhost:10201/WpfStockService"));
    
    			base.InitializeRuntime();
    		}
    	}
    }
