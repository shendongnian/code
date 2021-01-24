    float stringLength = 0F;
    string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
    StringFormat MarqueeFormat = new StringFormat(StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox)
    {
        Alignment = StringAlignment.Near,
        Trimming = StringTrimming.None
    };
    private void lblMarquee1_Paint(object sender, PaintEventArgs e)
    {
        SizeF stringSize = e.Graphics.MeasureString(loremIpsum, ((Control)sender).Font, -1, MarqueeFormat);
        PointF stringLocation = new PointF(trackBar1.Value, (((Control)sender).Height - stringSize.Height) / 2);
        stringLength = ((Control)sender).ClientRectangle.Width - stringLocation.X;
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        e.Graphics.DrawString(loremIpsum, ((Control)sender).Font, Brushes.Black, stringLocation, MarqueeFormat);
        lblMarquee2.Invalidate();
    }
    private void lblMarquee2_Paint(object sender, PaintEventArgs e)
    {
        SizeF stringSize = e.Graphics.MeasureString(loremIpsum, ((Control)sender).Font, -1, MarqueeFormat);
        PointF stringLocation = new PointF(-stringLength, (((Control)sender).Height - stringSize.Height) / 2);
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        e.Graphics.DrawString(loremIpsum, ((Control)sender).Font, Brushes.Black, stringLocation, MarqueeFormat);
    }
    private void trackBar1_ValueChanged(object sender, EventArgs e)
    {
        lblMarquee1.Invalidate();
    }
