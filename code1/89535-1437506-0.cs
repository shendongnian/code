    using System;
    using System.ServiceModel;
    [ServiceContract]
    interface IContractA
    {
        [OperationContract]
        void A();
    }
    [ServiceContract]
    interface IContractB
    {
        [OperationContract]
        void B();
    }
    [ServiceContract]
    interface IContractC
    {
        [OperationContract]
        void C();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class Service : IContractA, IContractB, IContractC
    {
        public Service()
        {
        }
        public void A()
        {
            Console.WriteLine("A");
        }
        public void B()
        {
            Console.WriteLine("B");
        }
        public void C()
        {
            Console.WriteLine("C");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Uri address = new Uri("net.pipe://localhost/Service/");
            ServiceHost host = new ServiceHost(new Service(), address);
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            host.AddServiceEndpoint(typeof(IContractA), binding, string.Empty);
            host.AddServiceEndpoint(typeof(IContractB), binding, string.Empty);
            host.AddServiceEndpoint(typeof(IContractC), binding, string.Empty);
            host.Open();
            IContractA proxyA = ChannelFactory<IContractA>.CreateChannel(new NetNamedPipeBinding(), new EndpointAddress(address));
            proxyA.A();
            ((IClientChannel)proxyA).Close();
            IContractB proxyB = ChannelFactory<IContractB>.CreateChannel(new NetNamedPipeBinding(), new EndpointAddress(address));
            proxyB.B();
            ((IClientChannel)proxyB).Close();
            IContractC proxyC = ChannelFactory<IContractC>.CreateChannel(new NetNamedPipeBinding(), new EndpointAddress(address));
            proxyC.C();
            ((IClientChannel)proxyC).Close();
            host.Close();
        }
    }
