        static void Main()
		{
			//Configure JobHost
			var config = new JobHostConfiguration();
			config.Queues.BatchSize = 32;
			config.Queues.MaxDequeueCount = 6;
            // Create a custom configuration
            // If you're using DI you should get this from the kernel
			config.Queues.QueueProcessorFactory = new CustomQueueProcessorFactory();
			//Pass configuration to JobJost
			var host = new JobHost(config);
			// The following code ensures that the WebJob will be running continuously
			host.RunAndBlock();
		}
