    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    
    namespace TestService
    {
    	class Program
    	{
    		static void Main()
    		{
    			var serviceHost=new ServiceHost(typeof(Subscribe1), new Uri("net.tcp://localhost:8888"));
    			serviceHost.Description.Behaviors.Add(new ServiceMetadataBehavior());
    			serviceHost.AddServiceEndpoint(typeof(ISubscribe1), new NetTcpBinding(SecurityMode.None), string.Empty);
    			serviceHost.AddServiceEndpoint("IMetadataExchange", MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
    			serviceHost.Open();
    
    			Console.WriteLine("Working!");
    			while(Console.ReadKey(true).Key!=ConsoleKey.Escape) { }
    		}
    	}
    
    	[ServiceContract]
    	interface ICallbackBase
    	{
    		[OperationContract]
    		void CommonlyUsedMethod();
    	}
    
    	[ServiceContract]
    	interface ICallback1 : ICallbackBase
    	{
    		[OperationContract]
    		void SpecificMethod();
    	}
    
    	[ServiceContract(CallbackContract=typeof(ICallback1))]
    	interface ISubscribe1
    	{
    		[OperationContract]
    		void TestMethod();
    	}
    
    	[ServiceBehavior]
    	class Subscribe1 : ISubscribe1
    	{
    		[OperationBehavior]
    		public void TestMethod()
    		{
    		}
    	}
    }
