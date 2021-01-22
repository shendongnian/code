	public class MonitorLock : IDisposable
    {
        public static MonitorLock CreateLock(object value)
        {
            return new MonitorLock(value);
        }
        private readonly object _l;
        protected MonitorLock(object l)
        {
            _l = l;
            
            Console.WriteLine("Lock {0} attempt by {1}", _l, Thread.CurrentThread.ManagedThreadId);
            
            Monitor.Enter(_l);
            Console.WriteLine("Lock {0} held by {1}" , _l, Thread.CurrentThread.ManagedThreadId);
        }
        public void Dispose()
        {
            Monitor.Exit(_l);
            Console.WriteLine("Lock {0} released by {1}", _l, Thread.CurrentThread.ManagedThreadId);
        }
    }
