    public class NoLockInterceptor : IObserver<KeyValuePair<string, object>>
    {
        public void OnCompleted()
        {
        }
    
        public void OnError(Exception error)
        {
        }
    
        public void OnNext(KeyValuePair<string, object> value)
        {
            if (value.Key == RelationalEventId.CommandExecuting.Name)
            {
                var command = ((CommandEventData)value.Value).Command;
    
                // Do command.CommandText manipulation here
            }
        }
    }
