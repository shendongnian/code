    public class ChunkingDispatcher : IDispatcher
    {
        private IDispatcher dispatcher;
        private int numberOfJobsDispatched;
        private int chunkSize;
        public ChunkingDispatcher(IDispatcher dispatcher, int chunkSize)
        {
            this.dispatcher = dispatcher;
            this.chunkSize = chunkSize;
        }
        public void Dispatch(IJob job)
        {
            dispatcher.Dispatch(job);
            if (++numberOfJobsDispatched % chunkSize == 0)
                WaitForJobsToFinish();
        }
        public void WaitForJobsToFinish()
        {
            dispatcher.WaitForJobsToFinish();
        }
    }
