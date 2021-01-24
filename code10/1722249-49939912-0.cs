    [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo")]
    public static extern bool GetGUIThreadInfo(uint tId, out GUITHREADINFO threadInfo);
    
            [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
            public struct RECT
            {
                public uint Left;
                public uint Top;
                public uint Right;
                public uint Bottom;
            };
    
            [StructLayout(LayoutKind.Sequential)]    // Required by user32.dll
            public struct GUITHREADINFO
            {
                public uint cbSize;
                public uint flags;
                public IntPtr hwndActive;
                public IntPtr hwndFocus;
                public IntPtr hwndCapture;
                public IntPtr hwndMenuOwner;
                public IntPtr hwndMoveSize;
                public IntPtr hwndCaret;
                public RECT rcCaret;
            }; 
    
    private System.Windows.Point EvaluateCaretPosition()
            {
                caretPosition = new Point();
                try
                {
                    // Fetch GUITHREADINFO
                    GetCaretPosition();
                    caretPosition.X = (int)guiInfo.rcCaret.Left; //+ 25;
                    caretPosition.Y = (int)guiInfo.rcCaret.Bottom; //+ 25;
                    WinApiDelegate.ClientToScreen(guiInfo.hwndCaret, ref caretPosition);
                }
                catch (Exception Ex)
                {
                    GenerateConsolidatedErrorLog(Ex);
                }
                return new System.Windows.Point(caretPosition.X, caretPosition.Y);
            } 
           public void GetCaretPosition()
            {
                try
                {
                    guiInfo = new WinApiDelegate.GUITHREADINFO();
                    guiInfo.cbSize = (uint)Marshal.SizeOf(guiInfo);
                    // Get GuiThreadInfo into guiInfo
                    WinApiDelegate.GetGUIThreadInfo(0, out guiInfo);
                }
                catch (Exception Ex)
                {
                    GenerateConsolidatedErrorLog(Ex);
                }
            } 
