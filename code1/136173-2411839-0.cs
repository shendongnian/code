    public static Status State
    {
        get { return state; }
        set
        {
            SysInfoEventArgs sysInfo = new SysInfoEventArgs(state, value);
            state = value;
            var handler = OnStateChange;
            if (handler != null)
                handler(null, sysInfo);
        }
    }
