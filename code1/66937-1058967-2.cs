    public class StringWorker
    {
        private string m_someString;
        private IAsyncResult m_result;
        private Func<string> DoSomethingDelegate;
        public StringWorker(string someString)
        {
            DoSomethingDelegate = DoSomething;
        }
        private string DoSomething()
        {
            throw new NotImplementedException();
        }
       
        public IAsyncResult BeginDoSomething()
        {
            if (m_result != null) { throw new InvalidOperationException(); }
            m_result = DoSomethingDelegate.BeginInvoke(null, null);
            return m_result;
        }
        public string EndDoSomething()
        {
            return DoSomethingDelegate.EndInvoke(m_result);
        }
    }
