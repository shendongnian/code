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
