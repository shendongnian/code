    public class AsyncConsole // not thread safe
    {
        private static readonly Lazy<AsyncConsole> Instance =
            new Lazy<AsyncConsole>();
        private bool _keyPressed;
        private ConsoleKeyInfo _keyInfo;
        private bool DoReadKey(
            int millisecondsTimeout,
            out ConsoleKeyInfo keyInfo)
        {
            _keyPressed = false;
            _keyInfo = new ConsoleKeyInfo();
            Thread readKeyThread = new Thread(ReadKeyThread);
            readKeyThread.IsBackground = false;
            readKeyThread.Start();
            Thread.Sleep(millisecondsTimeout);
            if (readKeyThread.IsAlive)
            {
                try
                {
                    IntPtr stdin = GetStdHandle(StdHandle.StdIn);
                    CloseHandle(stdin);
                    readKeyThread.Join();
                }
                catch { }
            }
            readKeyThread = null;
            keyInfo = _keyInfo;
            return _keyPressed;
        }
        private void ReadKeyThread()
        {
            try
            {
                _keyInfo = Console.ReadKey();
                _keyPressed = true;
            }
            catch (InvalidOperationException) { }
        }
        public static bool ReadKey(
            int millisecondsTimeout,
            out ConsoleKeyInfo keyInfo)
        {
            return Instance.Value.DoReadKey(millisecondsTimeout, out keyInfo);
        }
        private enum StdHandle { StdIn = -10, StdOut = -11, StdErr = -12 };
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(StdHandle std);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hdl);
    }
