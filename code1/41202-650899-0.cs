    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    };
 
    [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
    public extern static void Win32GetSystemTime(ref SystemTime sysTime);
 
    [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
    public extern static bool Win32SetSystemTime(ref SystemTime sysTime);
 
    private void button1_Click(object sender, EventArgs e)
    {
        // Set system date and time
        SystemTime updatedTime = new SystemTime();
        updatedTime.Year = (ushort)2009;
        updatedTime.Month = (ushort)3;
        updatedTime.Day = (ushort)16;
        updatedTime.Hour = (ushort)10;
        updatedTime.Minute = (ushort)0;
        updatedTime.Second = (ushort)0;
        // Call the unmanaged function that sets the new date and time instantly
        Win32SetSystemTime(ref updatedTime);
    }  
