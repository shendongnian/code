    public class EfGlobalListener : IObserver<DiagnosticListener>
    {
        private readonly NoLockInterceptor _noLockInterceptor = new NoLockInterceptor();
    
        public void OnCompleted()
        {
        }
    
        public void OnError(Exception error)
        {
        }
    
        public void OnNext(DiagnosticListener listener)
        {    
            if (listener.Name == DbLoggerCategory.Name)
            {
                listener.Subscribe(_noLockInterceptor);
            }
        }
    }
