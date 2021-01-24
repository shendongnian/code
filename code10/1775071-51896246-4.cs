    public delegate string KeysProducer();
    
    public class KeySender
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();
    
        private IntPtr initialFocus = IntPtr.Zero;
        private DateTime _startTime = DateTime.Now;
        private Timer _timer = null;
    
        private KeysProducer keysProducer = null;
    
        public KeySender(KeysProducer source)
        { keysProducer = source;  initialFocus = GetFocus(); }
        public KeySender(IntPtr Focussed, KeysProducer source)
        { keysProducer = source;  initialFocus = Focussed; }
    
        public bool Sending()
        { return _timer!=null; }
        public void StopSendingKeys()
        {
            if (_timer != null) _timer.Enabled = false;
            _timer = null;
        }
    
        public void StartSendingKeys(int minutes, int intervalsec)
        {
            if (_timer == null)
            {
                _timer = new Timer() { Interval = intervalsec };
                _timer.Tick += (s, e) =>
                {
                    if (DateTime.Now - _startTime >= TimeSpan.FromMinutes(minutes))
                    { _timer.Enabled = false; _timer = null; }
                    else
                    if (initialFocus != GetFocus())
                    { _timer.Enabled = false; _timer = null; }
                    else
                    if (keysProducer!=null) SendKeys.Send(keysProducer());
                };
                _timer.Start();
            }
        } 
     }
