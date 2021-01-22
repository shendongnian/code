    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IContract
    {
        [OperationContract(IsOneWay = true)]
        void SendTheData(string s);
    }
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void ForwardTheData(string s);
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceConnection : IContract
    {
        private ICallback m_callback;
        public ServiceConnection()
        {
            m_callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            ServiceCore.Add(this);
        }
        public void SendTheData(string s)
        {
            ServiceCore.DataArrived(s);
        }
        public void SendToClient(string s)
        {
            m_callback.ForwardTheData(s);
        }
    }
    static public class ServiceCore
    {
        static private List<ServiceConnection> m_connections = new List<ServiceConnection>();
        
        public static void DataArrived(string s)
        {
            foreach(ServiceConnection conn in m_connections)
            {
                conn.SendTheData(s);
            }
        }
        public static void Add(ServiceConnection connection)
        {
            m_connections.Add(connection);
        }
    }
