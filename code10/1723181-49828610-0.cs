    public class LabelWithBadge : Label
    {
        public Color BadgeColor { get; set; }
        private Size BadgeSize { get; set; }
        public LabelWithBadge()
        {            
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            if (BadgeColor == null)
                BadgeColor = Color.Red;
            if (BadgeSize == null)
                BadgeSize = new Size(20, 20);
        }
        protected override Size SizeFromClientSize(Size clientSize)
        {
            var textSize = TextRenderer.MeasureText("doesn't matter", this.Font);
            this.BadgeSize = new Size(textSize.Height, textSize.Height);
            var baseSize = base.SizeFromClientSize(clientSize);
            return new Size(baseSize.Width + BadgeSize.Width, baseSize.Height);           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(new SolidBrush(this.BadgeColor), this.ClientSize.Width - this.BadgeSize.Width, 0, this.BadgeSize.Width, this.BadgeSize.Height);
            
        }
    }
