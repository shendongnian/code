    [DllImport("user32.dll")]
    public static extern int SendMessage(
                      int hWnd,      // handle to destination window
                      uint Msg,       // message
                      long wParam,  // first message parameter
                      long lParam   // second message parameter
                      );
 
