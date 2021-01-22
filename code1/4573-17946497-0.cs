    public class AsyncConsole // not thread safe
    {
        private static readonly Lazy<AsyncConsole> Instance =
            new Lazy<AsyncConsole>();
        private bool _keyPressed;
        private ConsoleKeyInfo _keyInfo;
        private bool DoReadKey(int millisecondsTimeout, out ConsoleKeyInfo keyInfo)
        {
            _keyPressed = false;
            _keyInfo = new ConsoleKeyInfo();
            Thread readKeyThread = new Thread(ReadKeyThread);
            readKeyThread.IsBackground = true;
            readKeyThread.Start();
            Thread.Sleep(millisecondsTimeout);
            if (readKeyThread.IsAlive)
            {
                try
                {
                    readKeyThread.Interrupt();
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
            catch (ThreadInterruptedException)
            {
            }
        }
        public static bool ReadKey(
            int millisecondsTimeout,
            out ConsoleKeyInfo keyInfo)
        {
            return Instance.Value.DoReadKey(millisecondsTimeout, out keyInfo);
        }
    }
