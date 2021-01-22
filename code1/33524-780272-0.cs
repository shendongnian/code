    class FailBehavior : IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            return;
        }
    
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            Console.WriteLine("The FailFast behavior has been applied.");
            var f = new FailOnError();
            foreach(ChannelDispatcher chanDisp in serviceHostBase.ChannelDispatchers)
            {
                chanDisp.ErrorHandlers.Add(f);      
            }
        }
    
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            return;
        }
    }
    
    class FailOnError : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            // this is called for every exception -- even ungraceful disconnects
            if( !(error is CommunicationException) )
                throw new TargetInvocationException( "WCF operation failed.", error );
            else
                throw new CommunicationException( "Unexpected communication problem. (see inner exception)", error );
    
            // Unreachable
            //return false; // other handlers should be called
        }
    
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            // Can't throw from here (it will be swallowed), and using Environment.FailFast
            // will result in all crashes going to the same WER bucket. We could create
            // another thread and throw on that, but instead I think throwing from HandleError
            // should work.
    
            //Console.WriteLine( "Unhandled exception: {0}", error );
            //Environment.FailFast("Unhandled exception thrown -- killing server");            
        }
    }
    
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Greetings from the server." );
    
            Uri uri = new Uri( "net.tcp://localhost:5678/ServerThatShouldCrash" );
            using( ServiceHost serviceHost = new ServiceHost( typeof( Server ), uri ) )
            {
                Binding binding = _CreateBinding();
    
                serviceHost.AddServiceEndpoint( typeof( IServer ),
                                                binding,
                                                uri );
                serviceHost.Description.Behaviors.Add(new FailBehavior());
                serviceHost.Open();
                
                // The service can now be accessed.
                Console.WriteLine( "The service is ready." );
                Console.WriteLine( "\nPress <ENTER> to terminate service.\n" );
                Console.ReadLine();
            }
        }
    
        private static Binding _CreateBinding()
        {
            NetTcpBinding netTcp = new NetTcpBinding( SecurityMode.None );
            netTcp.ReceiveTimeout = TimeSpan.MaxValue;
            netTcp.ReliableSession.InactivityTimeout = TimeSpan.MaxValue;
            return netTcp;
        } // end _CreateBinding()
    }
