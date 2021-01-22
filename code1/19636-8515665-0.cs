    public static bool Enabled
    {
        get
        {
            return Application.UseWaitCursor;
        }
    
        set
        {
            if (value == Application.UseWaitCursor)
            {
                return;
            }
    
            Application.UseWaitCursor = value;
            var handle = GetForegroundWindow();
            SendMessage(handle, 0x20, handle, (IntPtr)1);
        }
    }
