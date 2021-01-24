    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    string LabelText = "Some text that needs to fit";
    private void label1_Paint(object sender, PaintEventArgs e)
    {
        Label label = sender as Label;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        float TextWidth = e.Graphics.MeasureString(LabelText, label.Font, label.Size, StringFormat.GenericTypographic).Width;
        float scale = (label.ClientSize.Width - label.Padding.Left) / TextWidth;
        e.Graphics.ScaleTransform(scale, scale);
        using (SolidBrush brush = new SolidBrush(label.ForeColor))
            e.Graphics.DrawString(LabelText, label.Font, Brushes.White,  
                                  new RectangleF(PointF.Empty, label1.ClientSize), 
                                  StringFormat.GenericTypographic);
    }
