    public class AsyncCommandExecutor : ICommandExecutor
    {
        private readonly SynchronizationContext m_context;
    
        public AsyncCommandExecutor(SynchronizationContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            m_context = context;
        }
    
        public void Execute(Action command)
        {
            ThreadPool.QueueUserWorkItem(o => command());
    
        }
    
        public void ExecuteWithContinuation(Func<Action> command)
        {
            ThreadPool.QueueUserWorkItem(o =>
                                             {
                                                 var continuation = command();
                                                 m_context.Send(x => continuation(), null);
                                             });
        }
    }
