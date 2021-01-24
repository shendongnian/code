    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        Bitmap bmp = (Bitmap)pictureBox1.Image;
        Size sz = bmp.Size;
        Bitmap zoomed = (Bitmap)pictureBox2.Image;
        if (zoomed != null) zoomed.Dispose();
        float zoom = (float)(trackBar1.Value / 4f + 1);
        zoomed = new Bitmap((int)(sz.Width * zoom), (int)(sz.Height * zoom));
        using (Graphics g = Graphics.FromImage(zoomed))
        {
            if (cbx_interpol.Checked) g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(bmp, new Rectangle( Point.Empty, zoomed.Size) );
        }
        pictureBox2.Image = zoomed;
    }
