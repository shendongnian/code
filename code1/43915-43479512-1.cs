    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace StayOnTop
    {
        public partial class Form1 : Form
        {
            private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
            private const UInt32 SWP_NOSIZE = 0x0001;
            private const UInt32 SWP_NOMOVE = 0x0002;
            private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
            public Form1()
            {
                InitializeComponent();
                FormBorderStyle = FormBorderStyle.None;
                TopMost = true;
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                SetWindowPos(this.Handle, HWND_TOPMOST, 100, 100, 300, 300, TOPMOST_FLAGS);
            }
            protected override void WndProc(ref Message m)
            {
                const int RESIZE_HANDLE_SIZE = 10;
                switch (m.Msg)
                {
                    case 0x0084/*NCHITTEST*/ :
                        base.WndProc(ref m);
                        if ((int)m.Result == 0x01/*HTCLIENT*/)
                        {
                            Point screenPoint = new Point(m.LParam.ToInt32());
                            Point clientPoint = this.PointToClient(screenPoint);
                            if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)12/*HTTOP*/ ;
                                else
                                    m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                            }
                            else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)10/*HTLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)2/*HTCAPTION*/ ;
                                else
                                    m.Result = (IntPtr)11/*HTRIGHT*/ ;
                            }
                            else
                            {
                                if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                    m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                                else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                    m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                                else
                                    m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                            }
                        }
                        return;
                }
                base.WndProc(ref m);
            }
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x20000; // <--- use 0x20000
                    return cp;
                }
            }
        }
    }
