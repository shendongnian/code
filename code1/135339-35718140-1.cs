    public class SplitContainerCustomSplitter : SplitContainer
    {
        [DefaultValue(typeof(Color), "Black")]
        public Color SplitterColor { get; set; } = Color.Black;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            Rectangle rect = SplitterRectangle;
            using (Pen pen = new Pen(SplitterColor))
            {
                if (Orientation == Orientation.Horizontal)
                {
                    g.DrawLine(pen, rect.Left, rect.Top, rect.Left, rect.Bottom - 1);
                    g.DrawLine(pen, rect.Right - 1, rect.Top, rect.Right - 1, rect.Bottom - 1);
                }
                else
                {
                    g.DrawLine(pen, rect.Left, rect.Top, rect.Right - 1, rect.Top);
                    g.DrawLine(pen, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
                }
            }
        }
    }
