    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    string SampleText = "Sample Text to Flip";
    bool FlipX = false;
    bool FlipY = false;
    bool Outlined = false;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingMode = CompositingMode.SourceOver;
        e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        using (GraphicsPath path = new GraphicsPath())
        using (StringFormat format = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
        {
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            path.AddString(SampleText, new FontFamily("Segoe UI"), (int)FontStyle.Regular, 28, panel1.ClientRectangle, format);
            using (Matrix FlipXMatrix = new Matrix(-1, 0, 0, 1, panel1.Width, 0))
            using (Matrix FlipYMatrix = new Matrix(1, 0, 0, -1, 0, panel1.Height))
            using (Matrix TransformMatrix = new Matrix())
            {
                if (FlipX)
                {
                    TransformMatrix.Multiply(FlipXMatrix);
                }
                if (FlipY)
                {
                    TransformMatrix.Multiply(FlipYMatrix);
                }
                path.Transform(TransformMatrix);
                //Or e.Graphics.Transform = TransformMatrix;
                if (Outlined)
                {
                    e.Graphics.DrawPath(Pens.LawnGreen, path);
                }
                else
                {
                    e.Graphics.FillPath(Brushes.Orange, path);
                }
            }
        }
    }
    private void btnFlipX_Click(object sender, EventArgs e)
    {
        FlipX = !FlipX;
        panel1.Invalidate();
    }
    private void btnFlipY_Click(object sender, EventArgs e)
    {
        FlipY = !FlipY;
        panel1.Invalidate();
    }
    private void chkOutlined_CheckedChanged(object sender, EventArgs e)
    {
        Outlined = chkOutlined.Checked;
        panel1.Invalidate();
    }
