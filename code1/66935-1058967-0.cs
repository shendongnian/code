    public class StringWorker
    {
        private string m_someString;
        private IAsyncResult m_result;
        private Action DoSomethingDelegate;
        public StringWorker(string someString)
        {
            DoSomethingDelegate = DoSomething;
        }
        private void DoSomething()
        {
            throw new NotImplementedException();
        }
        public IAsyncResult BeginDoSomething()
        {
            if (m_result != null) { throw new InvalidOperationException(); }
            m_result = DoSomethingDelegate.BeginInvoke(null, null);
            return m_result;
        }
        public void EndDoSomething()
        {
            DoSomethingDelegate.EndInvoke(m_result);
        }
    }
