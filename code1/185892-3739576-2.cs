    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpChannel tcpChannel = new TcpChannel();
                ChannelServices.RegisterChannel(tcpChannel,true);
                Type requiredType = typeof(IFooMgr);
                IFooMgr remoteObject = (IFooMgr)Activator.GetObject(requiredType,
                    "tcp://localhost:1237/FooManager");
                IList<IFoo> foos = remoteObject.GetList();
                foreach (IFoo foo in foos)
                {
                     Console.WriteLine("IsProxy:{0}, Name:{1}",
                          RemotingServices.IsTransparentProxy(foo), foo.Name);
                }
                Console.ReadLine();
            }
        }
    }
