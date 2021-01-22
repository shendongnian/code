    public interface IServiceConnector<out TServiceInterface>
    {
        void Connect(Action<TServiceInterface> clientUsage);
        TResult Connect<TResult>(Func<TServiceInterface, TResult> channelUsage);
    }
    internal class ServiceConnector<TService, TServiceInterface> : IServiceConnector<TServiceInterface>
        where TServiceInterface : class where TService : ClientBase<TServiceInterface>, TServiceInterface, new()
    {
        public TResult Connect<TResult>(Func<TServiceInterface, TResult> channelUsage)
        {
            var result = default(TResult);
            Connect(channel =>
            {
                result = channelUsage(channel);
            });
            return result;
        }
        public void Connect(Action<TServiceInterface> clientUsage)
        {
            if (clientUsage == null)
            {
                throw new ArgumentNullException("clientUsage");
            }
            var isChanneldClosed = false;
            var client = new TService();
            try
            {
                clientUsage(client);
                client.Close();
                isChanneldClosed = true;
            }
            finally
            {
                if (!isChanneldClosed)
                {
                    client.Abort();
                }
            }
        }
    }
