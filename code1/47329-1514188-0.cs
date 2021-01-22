    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      UnregisterHotKey(this.Handle, MYKEYID);
    }
    protected override void WndProc(ref Message m) {
      if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == MYKEYID) {
        Console.Beep();
      }
      base.WndProc(ref m);
    }
    // P/Invoke declarations
    private const int WM_HOTKEY = 0x312;
    private const int MOD_ALT = 1;
    private const int MOD_CONTROL = 2;
    private const int MOD_SHIFT = 4;
    [DllImport("user32.dll")]
    private static extern int RegisterHotKey(IntPtr hWnd, int id, int modifier, Keys vk);
    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
