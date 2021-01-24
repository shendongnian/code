    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    bool PaintBorder = false;
    int RegionInSet = 8;
    private void button1_Click(object sender, EventArgs e)
    {
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddEllipse(RegionInSet, RegionInSet, pictureBox1.Width - (RegionInSet * 2), 
                            pictureBox1.Height - (RegionInSet * 2));
            Region region = new Region(path);
            pictureBox1.Region = region;
        }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        PaintBorder = true;
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (!PaintBorder) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.CompositingMode = CompositingMode.SourceOver;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        using (Pen penRed = new Pen(Color.Red, 12))
        {
            int PenRedOffset = (int)(penRed.Width / 2) + (penRed.Width % 2 == 0 ? -1 : 0);
            e.Graphics.DrawEllipse(penRed,
                new RectangleF(RegionInSet + PenRedOffset, RegionInSet + PenRedOffset,
                               pictureBox1.Width - (PenRedOffset * 2) - (RegionInSet * 2),
                               pictureBox1.Height - (PenRedOffset * 2) - (RegionInSet * 2)));
        }
    }
