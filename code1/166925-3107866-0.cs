    public class MyClass
    {
        public static Thread ThreadA;
        public static Thread ThreadB;
        private void RunThings()
        {
            ThreadA = new Thread(new ThreadStart(ThreadAWork));
            ThreadB = new Thread(new ThreadStart(ThreadBWork));
            ThreadA.Start();
            ThreadB.Start();
        }
        static void ThreadAWork()
        {
            // do some stuff
            // thread A will close now, all work is done.
        }
        static void ThreadBWork()
        {
            // do some stuff
            ThreadA.Abort(); // close thread A
            // thread B will close now, all work is done.
        }
    }
