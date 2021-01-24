    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
<!---->
    public class MyNumericUpDown : NumericUpDown
    {
        MyWindoHelper wh;
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            wh = new MyWindoHelper(Controls[1]);
        }
        protected override void Dispose(bool disposing)
        {
            if (wh != null)
                wh.DestroyHandle();
            base.Dispose(disposing);
        }
        class MyWindoHelper : NativeWindow
        {
            Control c; //For future reference if needed.
            public MyWindoHelper(Control control)
            {
                c = control;
                this.AssignHandle(c.Handle);
            }
            private const int WM_PASTE = 0x0302;
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool MessageBeep(int type);
            protected override void WndProc(ref Message m)
            {
                if (m.Msg != WM_PASTE)
                    base.WndProc(ref m);
                else
                    MessageBeep(0);
            }
        }
    }
