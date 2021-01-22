    // Server:
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
    
    // Client:
    using System;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;
    using RemotingSample;
    namespace RemotingSample
    {
        public class Client
        {
            public Client()
            { 
            }
            public static int Main(string[] args)
            {
                IpcChannel chan = new IpcChannel("Client");
                ChannelServices.RegisterChannel(chan);
                RemoteObject remObject = (RemoteObject)Activator.GetObject(
                            typeof(RemotingSample.RemoteObject),
                            "ipc://Server/RemotingServer");
                if (remObject == null)
                {
                    Console.WriteLine("cannot locate server");
                }
                else
                {
                    remObject.ReplyMessage("You there?");
                }
                return 0;
            }
        }
    }
    
    // Shared Library:
    using System;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    
    namespace RemotingSample
    {
        public class RemoteObject : MarshalByRefObject
        {
            public RemoteObject()
            {
                Console.WriteLine("Remote object activated");
            }
            public String ReplyMessage(String msg)
            {
                Console.WriteLine("Client : " + msg);//print given message on console
                return "Server : I'm alive !";
            }
        }
    }
