        private readonly SynchronizationContext _synchronizationContext;
        public ThreadGate()
        {
            _synchronizationContext = AsyncOperationManager.SynchronizationContext;
        }
        public void Post<T>(Action<T> raiseEventMethod, T e)
        {
            if (_synchronizationContext == null)
                ThreadPool.QueueUserWorkItem(delegate { raiseEventMethod(e); });
            else
                _synchronizationContext.Post(delegate { raiseEventMethod(e); }, null);
        }
    }
