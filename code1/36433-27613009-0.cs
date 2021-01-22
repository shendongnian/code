    public class WcfInvoker<TService>
        where TService : ICommunicationObject
    {
        readonly Func<TService> _clientFactory;
        public WcfInvoker(Func<TService> clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public T Invoke<T>(Func<TService, T> action)
        {
            var client = _clientFactory();
            try
            {
                var result = action(client);
                client.Close();
                return result;
            }
            catch
            {
                client.Abort();
                throw;
            }
        }
        public void Invoke(Action<TService> action)
        {
            Invoke<object>(client =>
            {
                action(client);
                return null;
            });
        }
    }
