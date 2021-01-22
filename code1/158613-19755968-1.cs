    class ProcessHandler : Exception
    {
        private enum ProcessType
        {
            Try,
            Catch,
            Finally,
        }
        private Boolean _hasException;
        private Boolean _hasTryException;
        private Boolean _hasCatchException;
        private Boolean _hasFinnallyException;
        public Boolean HasException { get { return _hasException; } }
        public Boolean HasTryException { get { return _hasTryException; } }
        public Boolean HasCatchException { get { return _hasCatchException; } }
        public Boolean HasFinnallyException { get { return _hasFinnallyException; } }
        public Dictionary<String, Exception> Exceptions { get; private set; } 
        public readonly Action TryAction;
        public readonly Action CatchAction;
        public readonly Action FinallyAction;
        public ProcessHandler(Action tryAction = null, Action catchAction = null, Action finallyAction = null)
        {
            TryAction = tryAction;
            CatchAction = catchAction;
            FinallyAction = finallyAction;
            _hasException = false;
            _hasTryException = false;
            _hasCatchException = false;
            _hasFinnallyException = false;
            Exceptions = new Dictionary<string, Exception>();
        }
        private void Invoke(Action action, ref Boolean isError, ProcessType processType)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {
                _hasException = true;
                isError = true;
                Exceptions.Add(processType.ToString(), exception);
            }
        }
        private void InvokeTryAction()
        {
            if (TryAction == null)
            {
                return;
            }
            Invoke(TryAction, ref _hasTryException, ProcessType.Try);
        }
        private void InvokeCatchAction()
        {
            if (CatchAction == null)
            {
                return;
            }
            Invoke(TryAction, ref _hasCatchException, ProcessType.Catch);
        }
        private void InvokeFinallyAction()
        {
            if (FinallyAction == null)
            {
                return;
            }
            Invoke(TryAction, ref _hasFinnallyException, ProcessType.Finally);
        }
        public void InvokeActions()
        {
            InvokeTryAction();
            if (HasTryException)
            {
                InvokeCatchAction();
            }
            InvokeFinallyAction();
            if (HasException)
            {
                throw this;
            }
        }
    }
