    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    class BufferedTreeView : TreeView {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            IntPtr style = (IntPtr)TVS_EX_DOUBLEBUFFER;
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)style, (IntPtr)style);
        }
        // P/Invoke:
        private const int TVS_EX_DOUBLEBUFFER = 0x004;
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
