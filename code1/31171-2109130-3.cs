    using System;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Http;
    using Core;
    
    namespace Client
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			HttpClientChannel serverChannel = new HttpClientChannel();
    			ChannelServices.RegisterChannel(serverChannel, false);
    
    			for (int i = 0; i < 5; i++)
    			{
    				ICountingService countingService =
    				    (ICountingService)Activator.GetObject(typeof(ICountingService),
    				    "http://localhost:8234/CountingService.rem");
    
    				int newValue = countingService.Increment();
    				Console.WriteLine("Value is " + newValue);
    			}
    
    			Console.WriteLine("Press enter to exit.");
    			Console.ReadLine();
    		}
    	}
    }
