    namespace Server
    {
        public class Foo : MarshalByRefObject, IFoo
        {
            public string Name
            {
                get;set;
            }
        }
        public class FooManager :  MarshalByRefObject, IFooMgr
        {
            public IList<IFoo> GetList()
            {
                IList<IFoo> fooList = new List<IFoo>();
                fooList.Add(new Foo { Name = "test" });
                fooList.Add(new Foo { Name = "test2" });
                return fooList;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ChannelServices.RegisterChannel(new TcpChannel(1237),true);
                System.Runtime.Remoting.RemotingServices.Marshal(new FooManager(),
                   "FooManager");
                Console.Read();
            }
        }
    }
