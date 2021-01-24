    public class ThreadSafeClass
    {
        Dispatcher _dispatcher;
        public ThreadSafeClass(Dispatcher dispatcher)
        {
             _dispatcher = dispatcher;
        }
        public void ThreadSafeAddItem(Item item)
        {
             _dispatcher.Invoke(() => AddItem(item));
        }
    }
