    public class CountdownLatch
    {
        private int m_remain;
        private EventWaitHandle m_event;
    
        public CountdownLatch(int count)
        {
            Reset(count);
        }
    
        public void Reset(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            m_remain = count;
            m_event = new ManualResetEvent(false);
            if (m_remain == 0)
            {
                m_event.Set();
            }
        }
    
        public void Signal()
        {
            // The last thread to signal also sets the event.
            if (Interlocked.Decrement(ref m_remain) == 0)
                m_event.Set();
        }
    
        public void Wait()
        {
            m_event.WaitOne();
        }
    }
