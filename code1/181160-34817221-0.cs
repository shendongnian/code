        public class WcfWrapper : IDisposable
        {
            private readonly OperationContextScope _operationContextScope;
            private readonly IClientChannel _clientChannel;
            public WcfWrapper(IClientChannel clientChannel)
            {
                _clientChannel = clientChannel;
                _operationContextScope = new OperationContextScope(_clientChannel);
            }
            public void Dispose()
            {
                _operationContextScope.Dispose();
            }
            public T Function<T>(Func<T> func)
            {
                try
                {
                    var result = func();
                    _clientChannel.Close();
                    return result;
                }
                catch (Exception ex)
                {
                    KTrace.Error(ex);
                    _clientChannel.Abort();
                    throw;
                }
            }
            public void Procedure(Action action)
            {
                try
                {
                    action();
                    _clientChannel.Close();
                }
                catch (Exception ex)
                {
                    KTrace.Error(ex);
                    _clientChannel.Abort();
                    throw;
                }
            }
        }
    }
