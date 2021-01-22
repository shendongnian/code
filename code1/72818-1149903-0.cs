       private void button1_Click(object sender, EventArgs e)
        {
            rAr();
            pictureBox1.Invalidate();
            cnt++;
        }
    private void picturebox1_Paint(object sender PaintEventArgs e)
    {
        using graphics g = e.Graphics()
        {
              g.Clear(Color.Violet);
              g.PixelOffsetMode = PixelOffsetMode.HighQuality;
              g.SmoothingMode = SmoothingMode.HighQuality;
              g.DrawCurve(pen1, points2);
    
        }
    }
