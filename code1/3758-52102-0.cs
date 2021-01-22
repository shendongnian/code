    [DllImport("wtsapi32.dll")]
    private static extern bool WTSRegisterSessionNotification(IntPtr hWnd,
    int dwFlags);
    
    [DllImport("wtsapi32.dll")]
    private static extern bool WTSUnRegisterSessionNotification(IntPtr
    hWnd);
    
    private const int NotifyForThisSession = 0; // This session only
    
    private const int SessionChangeMessage = 0x02B1;
    private const int SessionLockParam = 0x7;
    private const int SessionUnlockParam = 0x8;
    
    protected override void WndProc(ref Message m)
    {
        // check for session change notifications
        if (m.Msg == SessionChangeMessage)
        {
            if (m.WParam.ToInt32() == SessionLockParam)
                OnSessionLock(); // Do something when locked
            else if (m.WParam.ToInt32() == SessionUnlockParam)
                OnSessionUnlock(); // Do something when unlocked
        }
    
        base.WndProc(ref m);
        return;
    }
    
    void OnSessionLock() 
    {
        Debug.WriteLine("Locked...");
    }
    
    void OnSessionUnlock() 
    {
        Debug.WriteLine("Unlocked...");
    }
    
    private void Form1Load(object sender, EventArgs e)
    {
        WTSRegisterSessionNotification(this.Handle, NotifyForThisSession);
    }
    // and then when we are done, we should unregister for the notification
    //  WTSUnRegisterSessionNotification(this.Handle);
