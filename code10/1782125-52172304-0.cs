    public static class DispatcherHelper
    {
        public static void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }
        private static object ExitFrame(object frame)
        {
            ((DispatcherFrame)frame).Continue = false;
            return null;
        }
    }
    public class Test
    {
        internal static bool _busy = false;
        
        internal static Dispatcher _dispatcher;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Main (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")");
            _dispatcher = Dispatcher.CurrentDispatcher;
            
            Task.Run(() => RunTask());
            DispatcherHelper.DoEvents();
            DispatcherHelper.DoEvents();
        }
        
        public static Task RunTask()
        {
            Console.WriteLine("RunTask (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")");
            _busy = true;
            _dispatcher.Invoke(new Action(CallBack));
            
            while (_busy == true)
            {
            }
            return null;
        }
        
        public static void CallBack()
        {
            Console.WriteLine("CallBack (ThreadId = " + Thread.CurrentThread.ManagedThreadId + ")");
            _busy = false;
        }
    }
