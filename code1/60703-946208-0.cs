    public class MyPanel : Panel
    {
        public string TextToRender
        {
            get;
            set;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString(this.TextToRender, new Font("Tahoma", 5), Brushes.White, new PointF(1, 1));
        }
    }
