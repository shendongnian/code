    class Program
    {
        static void Main(string[] args)
        {
            MyTimer.Create(
                () => { Console.WriteLine("hello"); },
                5000);
            Console.Read();
        }
    }
    public class MyTimer
    {
        private MyTimer() { }
        private Timer _timer;
        private ManualResetEvent _mre;
        private void WaitThenDispose()
        {
            _mre.WaitOne();
            _timer.Dispose();
        }
        public static void Create(
            Action action, 
            int dueTime)
        {
            var timer = new MyTimer();
            timer._mre = new ManualResetEvent(false);
            timer._timer = new Timer(
                (x) => { action(); timer._mre.Set(); },
                null,
                dueTime,
                Timeout.Infinite
                );
            new Thread(new ThreadStart(timer.WaitThenDispose));
        }
        public static void Create<T>(
            TimerCallback action, T state, 
            int dueTime, 
            int period) where T : class 
        {
            var timer = new MyTimer();
            timer._mre = new ManualResetEvent(false);
            timer._timer = new Timer(
                (x) => { action(x as T); timer._mre.Set(); },
                state,
                dueTime,
                period
                );
            if (period != Timeout.Infinite)
                new Thread(new ThreadStart(timer.WaitThenDispose));
        }
    }
