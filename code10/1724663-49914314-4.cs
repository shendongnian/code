    namespace Server
    {
      public class HelloRemotingService : MarshalByRefObject, IHelloRemotingService.IHelloRemotingService
      {
        public HelloRemotingService()
        {
        }
    
        public void Insert(string Name, string Address, string Email, string Mobile)
        {
          Console.WriteLine("HelloRemotingService.Insert called");
    
        }
    
        public override object InitializeLifetimeService()
        {
          return null; // manage lifetime by myself
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("          .NET Remoting Test Server");
          Console.WriteLine("          *************************");
          Console.WriteLine();
    
          try
          {
            StartServer();
            Console.WriteLine("Server started");
            Console.WriteLine();
          }
          catch (Exception ex)
          {
            Console.WriteLine("Server.Main exception: " + ex);
          }
    
          Console.WriteLine("Press <ENTER> to exit.");
          Console.ReadLine();
    
          StopServer();
    
        }
    
        static void StartServer()
        {
          RegisterBinaryTCPServerChannel(500);
    
          RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
    
          RemotingConfiguration.RegisterWellKnownServiceType(typeof(HelloRemotingService), 
                                                             "Insert.rem", 
                                                             WellKnownObjectMode.Singleton);
        }
    
        static void StopServer()
        {
          foreach (IChannel channel in ChannelServices.RegisteredChannels)
          {
            try
            {
              ChannelServices.UnregisterChannel(channel);
            }
            catch(Exception ex)
            {
              Console.WriteLine("Server.StopServer exception: " + ex);
            }
          }
        }
    
        static void RegisterBinaryTCPServerChannel(int port, string name = "tcp srv")
        {
          IServerChannelSinkProvider firstServerProvider;
          IClientChannelSinkProvider firstClientProvider;
    
          var channelProperties                = new Hashtable();
          channelProperties["typeFilterLevel"] = TypeFilterLevel.Full;
          channelProperties["machineName"]     = Environment.MachineName;
          channelProperties["port"]            = port;
    
    
          // create server format provider
          var serverFormatProvider             = new BinaryServerFormatterSinkProvider(null, null); // binary formatter
          serverFormatProvider.TypeFilterLevel = TypeFilterLevel.Full;
          firstServerProvider                  = serverFormatProvider;
    
          // create client format provider
          var clientProperties                = new Hashtable();
          clientProperties["typeFilterLevel"] = TypeFilterLevel.Full;
          var clientFormatProvider            = new BinaryClientFormatterSinkProvider(clientProperties, null);
          firstClientProvider                 = clientFormatProvider;
    
          TcpChannel tcp = new TcpChannel(channelProperties, firstClientProvider, firstServerProvider);
          ChannelServices.RegisterChannel(tcp, false);
        }
      }
    }
