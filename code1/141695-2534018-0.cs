    public class ConcurrentAudio : IDisposable
    {
        public ConcurrentAudio()
        {
            _queue = new ConcurrentQueue<WaitCallback>();
            _waitHandle = new AutoResetEvent(false);
            _disposed = false;
            _thread = new Thread(RunAudioProcs);
            _thread.IsBackground = true;
            _thread.Name = "run-audio";
            _thread.Start(null); // pass whatever "state" you need
        }
    
        public void AddAudio(WaitCallback proc)
        {
            _queue.Enqueue(proc);
            _waitHandle.Set();
        }
    
        public void Dispose()
        {
            _disposed = true;
            _thread.Join(1000); // don't feel like waiting forever
            GC.SuppressFinalize(this);
        }
    
        private void RunAudioProcs(object state)
        {
            while (!_disposed)
            {
                try
                {
                    WaitCallback proc = null;
    
                    if (_queue.TryDequeue(out proc))
                        proc(state);
                    else
                        _waitHandle.WaitOne();
                }
                catch (Exception x)
                {
                    // Do something about the error...
                    Trace.WriteLine(string.Format("Error: {0}", x.Message), "error");
                }
            }
        }
    
        private ConcurrentQueue<WaitCallback> _queue;
        private EventWaitHandle _waitHandle;
        private bool _disposed;
        private Thread _thread;
    }
