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
