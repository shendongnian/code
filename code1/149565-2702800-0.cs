    public class Countdown : IDisposable
    {
        private readonly ManualResetEvent done;
        private readonly int total;
        private long current;
        public Countdown(int total)
        {
            this.total = total;
            current = total;
            done = new ManualResetEvent(false);
        }
        public void Signal()
        {
            if (Interlocked.Decrement(ref current) == 0)
            {
                done.Set();
            }
        }
        public void Wait()
        {
            done.WaitOne();
        }
        public void Dispose()
        {
            ((IDisposable)done).Dispose();
        }
    }
