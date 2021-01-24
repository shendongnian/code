    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetCursorPos(out MousePosition lpMousePosition);
 
    [StructLayout(LayoutKind.Sequential)]
    public struct MousePosition 
    {
        public int x;
        public int y;
    }
    private static int GetHoveredDisplay ()
    {
        // Get the absolute mouse coordinates
        MousePosition mp;
        GetCursorPos(out mp);
        // Get the relative mouse coordinates
        Vector3 r = Display.RelativeMouseAt(new Vector3(mp.x, mp.y));
        // Use the z coordinate
        int displayIndex = (int)r.z;
        return displayIndex;
    }
