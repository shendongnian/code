    public interface IJob
    {
        void Execute();
    }
    public class ThreadPoolDispatcher : IDispatcher
    {
        private IList<ManualResetEvent> resetEvents = new List<ManualResetEvent>();
        public void Dispatch(IJob job)
        {
            var resetEvent = CreateAndTrackResetEvent();
            var worker = new ThreadPoolWorker(job, resetEvent);
            ThreadPool.QueueUserWorkItem(new WaitCallback(worker.ThreadPoolCallback));
        }
        private ManualResetEvent CreateAndTrackResetEvent()
        {
            var resetEvent = new ManualResetEvent(false);
            resetEvents.Add(resetEvent);
            return resetEvent;
        }
        public void WaitForJobsToFinish()
        {
            WaitHandle.WaitAll(resetEvents.ToArray() ?? new ManualResetEvent[] { });
            resetEvents.Clear();
        }
    }
