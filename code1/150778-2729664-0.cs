    class MyLabel : System.Windows.Forms.Control
    {
        public MyLabel()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder3D(  e.Graphics, this.ClientRectangle, Border3DStyle.Etched, Border3DSide.All);
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Red, 0, 0);
        }
    }
