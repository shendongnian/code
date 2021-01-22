    public class Win32Session
    {
        private const int NOTIFY_FOR_THIS_SESSION = 0;
        private const int WM_WTSSESSION_CHANGE = 0x2b1;
        private const int WTS_SESSION_LOCK = 0x7;
        private const int WTS_SESSION_UNLOCK = 0x8;
        public event EventHandler MachineLocked;
        public event EventHandler MachineUnlocked;
        public Win32Session()
        {
            ComponentDispatcher.ThreadFilterMessage += ComponentDispatcher_ThreadFilterMessage;
        }
        void ComponentDispatcher_ThreadFilterMessage(ref MSG msg, ref bool handled)
        {
            if (msg.message == WM_WTSSESSION_CHANGE)
            {
                int value = msg.wParam.ToInt32();
                if (value == WTS_SESSION_LOCK)
                {
                    OnMachineLocked(EventArgs.Empty);
                }
                else if (value == WTS_SESSION_UNLOCK)
                {
                    OnMachineUnlocked(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnMachineLocked(EventArgs e)
        {
            EventHandler temp = MachineLocked;
            if (temp != null)
            {
                temp(this, e);
            }
        }
        protected virtual void OnMachineUnlocked(EventArgs e)
        {
            EventHandler temp = MachineUnlocked;
            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
