    public abstract class ThreadedLogger : IDisposable {
        Queue<Action> queue = new Queue<Action>();
        ManualResetEvent hasNewItems = new ManualResetEvent(false);
        ManualResetEvent terminate = new ManualResetEvent(false);
        ManualResetEvent waiting = new ManualResetEvent(false);
        Thread loggingThread; 
        public ThreadedLogger() {
            loggingThread = new Thread(new ThreadStart(ProcessQueue));
            loggingThread.IsBackground = true;
            // this is performed from a bg thread, to ensure the queue is serviced from a single thread
            loggingThread.Start();
        }
        void ProcessQueue() {
            while (true) {
                waiting.Set();
                int i = ManualResetEvent.WaitAny(new WaitHandle[] { hasNewItems, terminate });
                // terminate was signaled 
                if (i == 1) return; 
                hasNewItems.Reset();
                waiting.Reset();
                Queue<Action> queueCopy;
                lock (queue) {
                    queueCopy = new Queue<Action>(queue);
                    queue.Clear();
                }
                foreach (var log in queueCopy) {
                    log();
                }    
            }
        }
        public void LogMessage(LogRow row) {
            lock (queue) {
                queue.Enqueue(() => AsyncLogMessage(row));
            }
            hasNewItems.Set();
        }
        protected abstract void AsyncLogMessage(LogRow row);
        public void Flush() {
            waiting.WaitOne();
        }
        public void Dispose() {
            terminate.Set();
            loggingThread.Join();
        }
    }
