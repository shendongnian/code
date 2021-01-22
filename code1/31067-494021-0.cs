    public class EventWaiter<T> where T : EventArgs
    {
        private System.Threading.ManualResetEvent manualEvent;
        public EventWaiter(T e)
        {
            manualEvent = new System.Threading.ManualResetEvent(false);
            e += this.OnEvent;
        }
        public void OnEvent(object sender, EventArgs e)
        {
            manualEvent.Set();
        }
        public void WaitOne()
        {
            manualEvent.WaitOne();
        }
        public void Reset()
        {
            manualEvent.Reset();
        }
    }
