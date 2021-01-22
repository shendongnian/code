    using System.Runtime.InteropServices;
    
    const int HT_CAPTION = 0x2;
    const int WM_NCLBUTTONDOWN = 0xA1;
    [DllImportAttribute("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd,int Msg, int wParam, int lParam);
    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();    
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        ReleaseCapture();
        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
      }
    }
