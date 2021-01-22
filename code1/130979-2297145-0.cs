    using System;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;
    namespace RemotingSample
    {
        public class Server
        {
            public Server()
            { 
            }
            public static int Main(string[] args)
            {
                IpcChannel chan = new IpcChannel("Server");
                //register channel
                ChannelServices.RegisterChannel(chan, false);
                //register remote object
                RemotingConfiguration.RegisterWellKnownServiceType(
                            typeof(RemotingSample.RemoteObject),
                       "RemotingServer",
                       WellKnownObjectMode.SingleCall);
                Console.WriteLine("Server Activated");
                Console.ReadLine();
                return 0;
            }
        }
    }
