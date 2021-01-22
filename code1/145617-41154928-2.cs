    public static class SynchroniztionContextExtensions
    {
        public static SynchronizationContextAwaiter GetAwaiter (this   SynchronizationContext context) 
        {
            if(context == null) throw new ArgumentNullException("context");
            return new SynchronizationContextAwaiter(context);
        }
    }
