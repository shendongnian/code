    public class CirclePanel : Panel
    {
        public CirclePanel()
        {
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(Pens.Black, 0,0,this.Width-1,this.Height-1);
        }
    
        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;
            base.OnResize(e);
        }
    }
