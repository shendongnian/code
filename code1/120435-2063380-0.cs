    class LabelX : Label
    {
        protected override void OnPaint(PaintEventArgs e) {
            Point drawPoint = new Point(0, 0);
    
            string[] ary = Text.Split(new char[] { '|' });
            if (ary.Length == 2) {
                Font normalFont = this.Font;
    
                Font boldFont = new Font(normalFont, FontStyle.Bold);
    
                Size boldSize = TextRenderer.MeasureText(ary[0], boldFont);
                Size normalSize = TextRenderer.MeasureText(ary[1], normalFont);
    
                Rectangle boldRect = new Rectangle(drawPoint, boldSize);
                Rectangle normalRect = new Rectangle(
                    boldRect.Right, boldRect.Top, normalSize.Width, normalSize.Height);
    
                TextRenderer.DrawText(e.Graphics, ary[0], boldFont, boldRect, ForeColor);
                TextRenderer.DrawText(e.Graphics, ary[1], normalFont, normalRect, ForeColor);
            }
            else {
    
                TextRenderer.DrawText(e.Graphics, Text, Font, drawPoint, ForeColor);                
            }
