using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace BackgroundWorker
{
    public class BackgroundWorker
    {
        /// <summary>
        /// Raised when the task completes (you could enhance this event to return state in the event args)
        /// </summary>
        public event EventHandler TaskCompleted;
        /// <summary>
        /// Raised if an unhandled exception is thrown by the background worker
        /// </summary>
        public event EventHandler<BackgroundWorkerErrorEventArgs> BackgroundError;
        private ThreadStart BackgroundTask;
        private readonly ManualResetEvent WaitEvent = new ManualResetEvent(false);
        /// <summary>
        /// ThreadStart is the delegate that  you want to run on your background thread.
        /// </summary>
        /// <param name="backgroundTask"></param>
        public BackgroundWorker(ThreadStart backgroundTask)
        {
            this.BackgroundTask = backgroundTask;
        }
        private Thread BackgroundThread;
        /// <summary>
        /// Starts the background task
        /// </summary>
        public void Start()
        {
            this.BackgroundThread = new Thread(this.ThreadTask);
            this.BackgroundThread.Start();
        }
        private void ThreadTask()
        {
            // the task that actually runs on the thread
            try
            {
                this.BackgroundTask();
                // completed only fires on successful completion
                this.OnTaskCompleted(); 
            }
            catch (Exception e)
            {
                this.OnError(e);
            }
            finally
            {
                // signal thread exit (unblock the wait method)
                this.WaitEvent.Set();
            }
        }
        private void OnTaskCompleted()
        {
            if (this.TaskCompleted != null)
                this.TaskCompleted(this, EventArgs.Empty);
        }
        private void OnError(Exception e)
        {
            if (this.BackgroundError != null)
                this.BackgroundError(this, new BackgroundWorkerErrorEventArgs(e));
        }
        /// <summary>
        /// Blocks until the task either completes or errrors out
        /// returns false if the wait timed out.
        /// </summary>
        /// <param name="timeout">Timeout in milliseconds, -1 for infinite</param>
        /// <returns></returns>
        public bool Wait(int timeout)
        {
            return this.WaitEvent.WaitOne(timeout);
        }
    }
    public class BackgroundWorkerErrorEventArgs : System.EventArgs
    {
        public BackgroundWorkerErrorEventArgs(Exception error) { this.Error = error; }
        public Exception Error;
    }
}
