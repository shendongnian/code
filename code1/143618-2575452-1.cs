      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          this.FormBorderStyle = FormBorderStyle.None;
          this.DoubleBuffered = true;
          this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 25;   // Caption bar height;
    
        protected override void OnPaint(PaintEventArgs e) {
          Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
          ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
          rc = new Rectangle(0, 0, this.ClientSize.Width, 32);
          e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
    
        protected override void WndProc(ref Message m) {
          if (m.Msg == 0x84) {  // Trap WM_NCHITTEST
            Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
            pos = this.PointToClient(pos);
            if (pos.Y < cCaption) {
              m.Result = (IntPtr)2;  // HTCAPTION
              return;
            }
            if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip) {
              m.Result = (IntPtr)17; // HTBOTTOMRIGHT
              return;
            }
          }
          base.WndProc(ref m);
        }
      }
