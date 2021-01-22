    private const uint WM_GETTEXT = 0x000D;
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, 
        StringBuilder lParam);
    [STAThread]
    static void Main(string[] args)
    {
        foreach (var handle in EnumerateProcessWindowHandles(
            Process.GetProcessesByName("explorer").First().Id))
        {
            StringBuilder message = new StringBuilder(1000);
            SendMessage(handle, WM_GETTEXT, message.Capacity, message);
            Console.WriteLine(message);
        }
    }
