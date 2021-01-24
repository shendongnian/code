    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    private void label1_Paint(object sender, PaintEventArgs e)
    {
        Label label = sender as Label;
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        float TextWidth = e.Graphics.MeasureString(label.Text, label.Font, label.Size, StringFormat.GenericTypographic).Width;
        float scale = (label.ClientSize.Width - label.Padding.Left) / TextWidth;
        e.Graphics.Clear(label.BackColor);
        e.Graphics.ScaleTransform(scale, scale);
        using (SolidBrush brush = new SolidBrush(label.ForeColor))
            e.Graphics.DrawString(label.Text, label.Font, Brushes.White,  
                                  new RectangleF(PointF.Empty, label1.ClientSize), 
                                  StringFormat.GenericTypographic);
    }
