    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    bool flipX = false;
    bool flipY = false;
    bool outlined = false;
    float sampleFontEmSize = 28f;
    string sampleText = "Sample Text to Flip";
    FontFamily sampleFont = new FontFamily("Segoe UI");
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Panel panel = sender as Panel;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (GraphicsPath path = new GraphicsPath())
        using (StringFormat format = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
        {
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            path.AddString(sampleText, sampleFont, (int)FontStyle.Regular, sampleFontEmSize, panel.ClientRectangle, format);
            using (Matrix flipXMatrix = new Matrix(-1, 0, 0, 1, panel.Width, 0))
            using (Matrix flipYMatrix = new Matrix(1, 0, 0, -1, 0, panel.Height))
            using (Matrix transformMatrix = new Matrix())
            {
                if (flipX) {
                    transformMatrix.Multiply(flipXMatrix);
                }
                if (flipY) {
                    transformMatrix.Multiply(flipYMatrix);
                }
                path.Transform(transformMatrix);
                //Or e.Graphics.Transform = TransformMatrix;
                if (outlined) {
                    e.Graphics.DrawPath(Pens.LawnGreen, path);
                }
                else {
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
