    //Overflow gets inlined to here. (In System.Windows.Shell.WindowChromeWorker.cs)
    var mousePosScreen = new Point(Utility.GET_X_LPARAM(lParam), Utility.GET_Y_LPARAM(lParam));
    
    //Which calls this (In Standard.Utility)
    public static int GET_X_LPARAM(IntPtr lParam)
    {
        return LOWORD(lParam.ToInt32());
    }
    
    //Unsafe cast and overflow happens here (In System.IntPtr)
    public unsafe int ToInt32() {
        #if WIN32
            return (int)m_value;
        #else
            long l = (long)m_value;
            return checked((int)l); //Overflow actually occurs and is thrown from here.
        #endif
    }
