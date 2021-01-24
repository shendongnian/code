    using System;
    using System.Windows.Forms;
    public class MyDomainUpDown : DomainUpDown
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
            protected override void WndProc(ref Message m)
            {
                if (m.Msg != 0x0302 /*WM_PASTE*/)
                    base.WndProc(ref m);
                else
                    System.Media.SystemSounds.Beep.Play();
            }
        }
    }
