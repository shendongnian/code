    public class Original
    {
        public ResultType Operation(ParamType param){...}
        public IAsyncResult BeginOperation(ParamType param, AsyncCallback callback, object state){...}
        public ResultType EndOperation(IAsyncResult ar){...}
    }
    public class Wrapper
    {
        private AsyncFunc<ParamType, ResultType> _operation;
        private Original _original;
        
        public Wrapper(Original original)
        {
            _original = original;
            _operation = AsyncFunc<ParamType, ResultType>(_original.Operation);
        }
        public ResultType Operation(ParamType param)
        {
            return _original.Operation(param);
        }
        
        public void OperationAsync(ParamType param)
        {
            _operation.InvokeAsync(param)
        }
        
        public event AsyncFuncCompletedEventHandler<ResultType> OperationCompleted      
          {
            add { _operation.Completed += value; }
            remove { _operation.Completed -= value; }
        }
    }
