    float StringLength = 0F;
    string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
    StringFormat Marqueeformat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox)
    {
        Alignment = StringAlignment.Near,
        Trimming = StringTrimming.None
    };
    private void lblMarquee1_Paint(object sender, PaintEventArgs e)
    {
        SizeF StringSize = e.Graphics.MeasureString(LoremIpsum, ((Control)sender).Font, -1, Marqueeformat);
        PointF StringLocation = new PointF(trackBar1.Value, (((Control)sender).Height - StringSize.Height) / 2);
        StringLength = ((Control)sender).ClientRectangle.Width - StringLocation.X;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        e.Graphics.DrawString(LoremIpsum, ((Control)sender).Font, Brushes.Black, StringLocation, Marqueeformat);
        lblMarquee2.Invalidate();
    }
    private void lblMarquee2_Paint(object sender, PaintEventArgs e)
    {
        SizeF StringSize = e.Graphics.MeasureString(LoremIpsum, ((Control)sender).Font, -1, Marqueeformat);
        PointF StringLocation = new PointF(-StringLength, (((Control)sender).Height - StringSize.Height) / 2);
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        e.Graphics.DrawString(LoremIpsum, ((Control)sender).Font, Brushes.Black, StringLocation, Marqueeformat);
    }
    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
        lblMarquee1.Invalidate();
    }
