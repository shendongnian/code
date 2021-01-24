    class Program
    {
        static void Main(string[] args)
        {
            DuplexChannelFactory<IDemo> factory = new DuplexChannelFactory<IDemo>(new CallbackHandler(), "test_ep");
            IDemo channel = factory.CreateChannel();
            Console.WriteLine("Start to Call");
            channel.PostNumber(15);
            Console.WriteLine("Calling is done");
            Console.ReadLine();
        }
    }
    [ServiceContract(Namespace ="mydomain",Name = "demo", ConfigurationName = "isv", CallbackContract = typeof(ICallback))]
    public interface IDemo
    {
        [OperationContract(Action = "post_num",IsOneWay =true)]
        void PostNumber(int n);
    }
    [ServiceContract]
    public interface ICallback
    {
        [OperationContract(Action = "report",IsOneWay =true)]
        void Report(double progress);
    }
    public class CallbackHandler : ICallback
    {
        public void Report(double progress)
        {
            Console.WriteLine("{0:p0}", progress);
        }
    }
