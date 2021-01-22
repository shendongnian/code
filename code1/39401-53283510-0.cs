            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
            private IntPtr _ClipboardViewerNext;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _ClipboardViewerNext = SetClipboardViewer(this.Handle);
            }
    
            protected override void WndProc(ref System.Windows.Forms.Message m)
            {
                const int WM_DRAWCLIPBOARD = 0x308;
    
                switch (m.Msg)
                {
                    case WM_DRAWCLIPBOARD:
                        //Clipboard is Change 
                        //your code..............
                        break; 
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
