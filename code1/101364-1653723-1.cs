    [DllImport("user32.dll")]
    private static extern int MessageBox(IntPtr hWnd, String
    text, String caption, uint type);
    static void Main(string[] args)
    {
    MessageBox(new IntPtr(0), "Hello, world!", "My box", 0);
    }
