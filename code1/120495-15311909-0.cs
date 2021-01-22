    static class ProcessWatcher
    {
        public static void StartWatch()
        {
            _timer = new Timer(100);
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            _timer.Start();
        }
        static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            setLastActive();
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        public static IntPtr LastHandle
        {
            get
            {
                return _previousToLastHandle;
            }
        }
        private static void setLastActive()
        {
            IntPtr currentHandle = GetForegroundWindow();
            if (currentHandle != _previousHandle)
            {
                _previousToLastHandle = _previousHandle;
                _previousHandle = currentHandle;
            }
        }
        private static Timer _timer;
        private static IntPtr _previousHandle = IntPtr.Zero;
        private static IntPtr _previousToLastHandle = IntPtr.Zero;
    }
