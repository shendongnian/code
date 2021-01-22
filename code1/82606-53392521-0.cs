    public enum SystemMetric
    {
        VirtualScreenWidth = 78, // CXVIRTUALSCREEN 0x0000004E 
        VirtualScreenHeight = 79, // CYVIRTUALSCREEN 0x0000004F 
    }
    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(SystemMetric metric);
    public static Size GetVirtualDisplaySize()
    {
        var width = GetSystemMetrics(SystemMetric.VirtualScreenWidth);
        var height = GetSystemMetrics(SystemMetric.VirtualScreenHeight);
    
        return new Size(width, height);
    }
