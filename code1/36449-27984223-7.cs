    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        void DoWork();
    }
    public class ProxyDisposer : IDisposable
    {
        private IClientChannel _clientChannel;
        public ProxyDisposer(IClientChannel clientChannel)
        {
            _clientChannel = clientChannel;
        }
        public void Dispose()
        {
            var success = false;
            try
            {
                _clientChannel.Close();
                success = true;
            }
            finally
            {
                if (!success)
                    _clientChannel.Abort();
                _clientChannel = null;
            }
        }
    }
    public class ProxyWrapper : IMyService, IDisposable
    {
        private IMyService _proxy;
        private IDisposable _proxyDisposer;
        public ProxyWrapper(IMyService proxy, IDisposable disposable)
        {
            _proxy = proxy;
            _proxyDisposer = disposable;
        }
        public void DoWork()
        {
            _proxy.DoWork();
        }
        public void Dispose()
        {
            _proxyDisposer.Dispose();
        }
    }
