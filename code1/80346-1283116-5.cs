    class Program
    {
        static void Main(string[] args)
        {
            var items = new string[] { "1", "2", "3", "300" };
            using (var outfile = File.AppendText("file.txt"))
            {
                using (var ws = new WorkSet<string>(x =>
                        { lock (outfile) outfile.WriteLine(x); }))
                    foreach (var item in items)
                        ws.Process(item);
            }
        }
        public class WorkSet<T> : IDisposable
        {
            #region Interface
            public WorkSet(Action<T> action)
            { _action = action; }
            public void Process(T item)
            {
                Interlocked.Increment(ref _workItems);
                ThreadPool.QueueUserWorkItem(o =>
                        { try { _action((T)o); } finally { Done(); } }, item);
            }
            #endregion
            #region Advanced
            public bool Done()
            {
                if (Interlocked.Decrement(ref _workItems) != 0)
                    return false;
                _finished.Set();
                return true;
            }
            public ManualResetEvent Finished
            { get { return _finished; } }
            #endregion
            #region IDisposable
            public void Dispose()
            {
                Done();
                _finished.WaitOne();
            }
            #endregion
            #region Fields
            readonly Action<T> _action;
            readonly ManualResetEvent _finished = new ManualResetEvent(false);
            int _workItems = 1;
            #endregion
        }
    }
