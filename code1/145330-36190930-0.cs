    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class TabControlEx:TabControl
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        private const int WM_PAINT = 0x0f;
        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1d;
        private System.Drawing.Bitmap buffer;
        private Timer timer = new Timer();
        public TabControlEx()
        {
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
            timer.Stop();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PAINT) timer.Start();
            base.WndProc(ref m);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            this.SetStyle(ControlStyles.UserPaint, false);
            base.OnPaint(pevent);
            System.Drawing.Rectangle o = pevent.ClipRectangle;
            System.Drawing.Graphics.FromImage(buffer).Clear(System.Drawing.SystemColors.Control);
            if (o.Width > 0 && o.Height > 0)
            DrawToBitmap(buffer, new System.Drawing.Rectangle(0, 0, Width, o.Height));
            pevent.Graphics.DrawImageUnscaled(buffer, 0, 0);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            buffer = new System.Drawing.Bitmap(Width, Height);
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, (IntPtr)(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }
    }
