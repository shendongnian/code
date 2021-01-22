    public interface IMyContractCallback
    {
        [OperationContract]
        void OnCallback();
    }
    [ServiceContract(CallbackContract = typeof(IMyContractCallback))]
    public interface IMyContract
    {
        [OperationContract]
        void DoSomething();
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class MyService : IMyContract
    {
        public void DoSomething()
        {
            Console.WriteLine("Hi from server!");
            var callback = OperationContext.Current.GetCallbackChannel<IMyContractCallback>();
            callback.OnCallback();
        }
    }
    public class MyContractClient : DuplexClientBase<IMyContract>
    {
        public MyContractClient(object callbackInstance, Binding binding, EndpointAddress remoteAddress)
            : base(callbackInstance, binding, remoteAddress) { }
    }
    public class MyCallbackClient : IMyContractCallback
    {
        public void OnCallback()
        {
            Console.WriteLine("Hi from client!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("net.tcp://localhost");
            var binding = new NetTcpBinding();
            var host = new ServiceHost(typeof(MyService), uri);
            host.AddServiceEndpoint(typeof(IMyContract), binding, "");
            host.Open();
            var callback = new MyCallbackClient();
            var client = new MyContractClient(callback, binding, new EndpointAddress(uri));
            var proxy = client.ChannelFactory.CreateChannel();
            proxy.DoSomething();
            // Printed in console:
            //  Hi from server!
            //  Hi from client!
            client.Close();
            host.Close();
        }
    }
