    using System;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Http;
    
    namespace Server
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			HttpServerChannel serverChannel = new HttpServerChannel(8234);
    			ChannelServices.RegisterChannel(serverChannel, false);
    
    			// Following line won't work at runtime as there is no parameterless constructor
    			//RemotingConfiguration.RegisterWellKnownServiceType(typeof(CountingService),
    			//                     "CountingService.rem", WellKnownObjectMode.Singleton);
    			
    			CountingService countingService = new CountingService(5);
    			RemotingServices.Marshal(countingService, "CountingService.rem");
    
    			Console.WriteLine("Press enter to exit.");
    			Console.ReadLine();
    		}
    	}
    }
