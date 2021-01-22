    class RequestProcessingThread
    {
        // Used to signal this thread when there is new work to be done
        private AutoResetEvent _processingNeeded = new AutoResetEvent(true);
    
        // Used for request to terminate processing
        private ManualResetEvent _stopProcessing = new ManualResetEvent(false);
    
        // Signalled when thread has stopped processing
        private AutoResetEvent _processingStopped = new AutoResetEvent(false);
    
        /// <summary>
        /// Called to start processing
        /// </summary>
        public void Start()
        {
            _stopProcessing.Reset();
    
            Thread thread = new Thread(ProcessRequests);
            thread.Start();
        }
    
        /// <summary>
        /// Called to request a graceful shutdown of the processing thread
        /// </summary>
        public void Stop()
        {
            _stopProcessing.Set();
    
            // Optionally wait for thread to terminate here
            _processingStopped.WaitOne();
        }
    
        /// <summary>
        /// This method does the actual work
        /// </summary>
        private void ProcessRequests()
        {
            WaitHandle[] waitHandles = new WaitHandle[] { _processingNeeded, _stopProcessing };
    
            Foo.RequestAdded += OnRequestAdded;
    
            while (true)
            {
                while (Foo.Requests.Count > 0)
                {
                    string request;
                    lock (Foo.Requests)
                    {
                        request = Foo.Requests.Peek();
                    }
    
                    // Process request
                    Debug.WriteLine(request);
    
                    lock (Foo.Requests)
                    {
                        Foo.Requests.Dequeue();
                    }
                }
    
                if (WaitHandle.WaitAny(waitHandles) == 1)
                {
                    // _stopProcessing was signalled, exit the loop
                    break;
                }
            }
    
            Foo.RequestAdded -= ProcessRequests;
    
            _processingStopped.Set();
        }
    
        /// <summary>
        /// This method will be called when a new requests gets added to the queue
        /// </summary>
        private void OnRequestAdded()
        {
            _processingNeeded.Set();
        }
    }
    
    
    static class Foo
    {
        public delegate void RequestAddedHandler();
        public static event RequestAddedHandler RequestAdded;
    
        static Foo()
        {
            Requests = new Queue<string>();
        }
    
        public static Queue<string> Requests
        {
            get;
            private set;
        }
    
        public static void AddRequest(string request)
        {
            lock (Requests)
            {
                Requests.Enqueue(request);
            }
    
            if (RequestAdded != null)
            {
                RequestAdded();
            }
        }
    }
