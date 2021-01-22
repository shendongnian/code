    // strongly typed weak reference
    public class WeakReference<T> : WeakReference
        where T : class
    {
        public WeakReference(T target)
            : base(target)
        { }
        public WeakReference(T target, bool trackResurrection)
            : base(target, trackResurrection)
        { }
        public new T Target
        {
            get { return base.Target as T; }
            set { base.Target = value; }
        }
    }
    // weak referenced generic event handler
    public class WeakEventHandler<TEventArgs> : WeakReference<EventHandler<TEventArgs>>
        where TEventArgs : EventArgs
    {
        public WeakEventHandler(EventHandler<TEventArgs> target)
            : base(target)
        { }
        protected void Invoke(object sender, TEventArgs e)
        {
            if (Target != null)
            {
                Target(sender, e);
            }
        }
        public static implicit operator EventHandler<TEventArgs>(WeakEventHandler<TEventArgs> weakEventHandler)
        {
            if (weakEventHandler != null)
            {
                if (weakEventHandler.IsAlive)
                {
                    return weakEventHandler.Invoke;
                }
            }
            return null;
        }
    }
    // weak reference common event handler
    public class WeakEventHandler : WeakReference<EventHandler>
    {
        public WeakEventHandler(EventHandler target)
            : base(target)
        { }
        protected void Invoke(object sender, EventArgs e)
        {
            if (Target != null)
            {
                Target(sender, e);
            }
        }
        public static implicit operator EventHandler(WeakEventHandler weakEventHandler)
        {
            if (weakEventHandler != null)
            {
                if (weakEventHandler.IsAlive)
                {
                    return weakEventHandler.Invoke;
                }
            }
            return null;
        }
    }
    // observable class, fires events
    public class Observable
    {
        public Observable() { Console.WriteLine("new Observable()"); }
        ~Observable() { Console.WriteLine("~Observable()"); }
        public event EventHandler OnChange;
        protected virtual void DoOnChange()
        {
            EventHandler handler = OnChange;
            if (handler != null)
            {
                Console.WriteLine("DoOnChange()");
                handler(this, EventArgs.Empty);
            }
        }
        public void Change()
        {
            DoOnChange();
        }
    }
    // observer, event listener
    public class Observer
    {
        public Observer() { Console.WriteLine("new Observer()"); }
        ~Observer() { Console.WriteLine("~Observer()"); }
        public void OnChange(object sender, EventArgs e)
        {
            Console.WriteLine("-> Observer.OnChange({0}, {1})", sender, e);
        }
    }
    // sample usage and test code
    public static class Program
    {
        static void Main()
        {
            Observable subject = new Observable();
            Observer watcher = new Observer();
            Console.WriteLine("subscribe new WeakEventHandler()\n");
            subject.OnChange += new WeakEventHandler(watcher.OnChange);
            subject.Change();
            Console.WriteLine("\nObserver = null, GC");
            watcher = null;
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            subject.Change();
            if (Debugger.IsAttached)
            {
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
