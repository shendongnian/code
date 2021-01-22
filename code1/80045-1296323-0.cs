    public class WorkObjectHandle : IAsyncResult, IDisposable
    {
        private int _percentComplete;
        private ManualResetEvent _waitHandle;
        public int PercentComplete {
            get {return _percentComplete;} 
            set 
            {
                if (value < 0 || value > 100) throw new InvalidArgumentException("Percent complete should be between 0 and 100");
                if (_percentComplete = 100) throw new InvalidOperationException("Already complete");
                if (value == 100 && Complete != null) Complete(this, new CompleteArgs(WorkObject));
                _percentComplete = value;
            } 
        public IWorkObject WorkObject {get; private set;}
        public object AsyncState {get {return WorkObject;}}
        public bool IsCompleted {get {return _percentComplete == 100;}}
        public event EventHandler<CompleteArgs> Complete; // CompleteArgs in a usual pattern
        // you may also want to have Progress event
        public bool CompletedSynchronously {get {return false;}}
        public WaitHandle
        {
            get
            {
                // initialize it lazily
                if (_waitHandle == null)
                {
                    ManualResetEvent newWaitHandle = new ManualResetEvent(false);
                    if (Interlocked.CompareExchange(ref _waitHandle, newWaitHandle, null) != null)
                        newWaitHandle.Dispose();
                }
                return _waitHandle;
            }
        }
        public void Dispose() 
        {
             if (_waitHandle != null)
                 _waitHandle.Dispose();
             // dispose _workObject too, if needed
        }
        public WorkObjectHandle(IWorkObject workObject) 
        {
            WorkObject = workObject;
            _percentComplete = 0;
        }
    }
    public class AsyncScheduler 
    {
        private Queue<WorkObjectHandle> _workQueue = new Queue<WorkObjectHandle>();
        private bool _finished = false;
    
        public WorkObjectHandle QueueAsyncWork(IWorkObject workObject)
        {
            var handle = new WorkObjectHandle(workObject);
            lock(_workQueue) 
            {
                _workQueue.Enqueue(handle);
            }
            return handle;
        }
    
        private void WorkThread()
        {
            // simplified for the sake of example
            while (!_finished)
            {
                WorkObjectHandle handle;
                lock(_workQueue) 
                {
                    if (_workQueue.Count == 0) break;
                    handle = _workQueue.Dequeue();
                }
                try
                {
                    var workObject = handle.WorkObject;
                    // do whatever you want with workObject, set handle.PercentCompleted, etc.
                }
                finally
                {
                    handle.Dispose();
                }
            }
        }
    }
