    public class ConnectionToService<TInterface> : where TInterface : class
    {
        public TResult ExecuteCommand<TResult>(Func<TInterface, TResult> method)
        {
            var channel = _strategyFactory.CreateChannel<CarServiceSoapChannel>();
    
            return method(channel);
        }
    }
