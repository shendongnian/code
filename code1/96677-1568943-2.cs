    class Program
    {
        static void Main(string[] args)
        {
            MyTimer.Create(
                () => { Console.WriteLine("hello"); },
                5000);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.Read();
        }
    }
    public class MyTimer
    {
        private MyTimer() { }
        private Timer _timer;
        private ManualResetEvent _mre;
        public static void Create(Action action, int dueTime)
        {
            var timer = new MyTimer();
            timer._mre = new ManualResetEvent(false);
            timer._timer = new Timer(
                (x) =>
                {
                    action();
                    timer._mre.Set();
                },
                null,
                dueTime,
                Timeout.Infinite
                );
            new Thread(new ThreadStart(() =>
            {
                timer._mre.WaitOne();
                timer._timer.Dispose();
            })).Start();
        }
    }
