    class CaptureEvents : IMessageFilter
    {
        #region IMessageFilter Members
        public delegate void Callback(int message);
        public event Callback MessageReceived;
        IntPtr ownerWindow;
        Hashtable interestedMessages = null;
        CaptureEvents(IntPtr handle, int[] messages)
        {
            ownerWindow = handle;
            for(int c = 0; c < messages.Length ; c++)
            {
                interestedMessages[messages[c]] = 0;
            }
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.HWnd == ownerWindow && interestedMessages.ContainsKey(m.Msg))
            {
                MessageReceived(m.Msg);
            }
            return true;
        }
        #endregion
    }
