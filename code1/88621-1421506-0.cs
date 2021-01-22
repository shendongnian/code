     public class UserActivityFilter : IMessageFilter
     {
            // Define WinAPI window message values (see pinvoke.net)
            private int WM_LBUTTONDOWN = 0x0201;
            private int WM_MBUTTONDOWN = 0x0207;
            private int WM_RBUTTONDOWN = 0x0204;
            private int WM_MOUSEWHEEL = 0x020A;
            private int WM_MOUSEMOVE = 0x0200;
            private int WM_KEYDOWN = 0x0100;
    
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_MBUTTONDOWN || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_MOUSEWHEEL || m.Msg == WM_MOUSEMOVE || m.Msg == WM_KEYDOWN)
                {
                    //User activity has occurred
                    // Reset a flag / timer etc.
                }
                return false;
            }
      }
