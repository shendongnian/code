    using System;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class SetDialogButton : IDisposable {
        private Timer mTimer = new Timer();
        private int mCtlId;
        private string mText;
    
        public SetDialogButton(int ctlId, string txt) {
            mCtlId = ctlId;
            mText = txt;
            mTimer.Interval = 50;
            mTimer.Enabled = true;
            mTimer.Tick += (o, e) => findDialog();
        }
    
        private void findDialog() {
            // Enumerate windows to find the message box
            EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
            if (!EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero)) mTimer.Enabled = false;
        }
        private bool checkWindow(IntPtr hWnd, IntPtr lp) {
            // Checks if <hWnd> is a dialog
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() != "#32770") return true;
            // Got it, get the STATIC control that displays the text
            IntPtr hCtl = GetDlgItem(hWnd, mCtlId);
            SetWindowText(hCtl, mText);
            // Done
            return true;
        }
        public void Dispose() {
            mTimer.Enabled = false;
        }
    
        // P/Invoke declarations
        private const int WM_SETFONT = 0x30;
        private const int WM_GETFONT = 0x31;
        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDlgItem(IntPtr hWnd, int item);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(IntPtr hWnd, string txt);
    }
