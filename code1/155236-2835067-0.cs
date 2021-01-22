    // Assuming a Form1 with 3 ProgressBar controls
    private void Form1_Load(object sender, EventArgs e)
    {
      SendMessage(progressBar2.Handle,
        0x400 + 16, //WM_USER + PBM_SETSTATE
        0x0003, //PBST_PAUSED
        0);
    
      SendMessage(progressBar3.Handle,
        0x400 + 16, //WM_USER + PBM_SETSTATE
        0x0002, //PBST_ERROR
        0);
    }
    
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern uint SendMessage(IntPtr hWnd,
      uint Msg,
      uint wParam,
      uint lParam);
