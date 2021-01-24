    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        points.Add(e.Location);
        pictureBox1.Invalidate();
        show_Length();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (points.Count > 1) e.Graphics.DrawLines(Pens.Red, points.ToArray());
    }
    void show_Length()
    {
        if (!(points.Count > 1)) return;
        double len = 0;
        for (int i = 1; i < points.Count; i++)
        {
            len += Math.Sqrt((points[i-1].X - points[i].X) * (points[i-1].X - points[i].X) 
                        +  (points[i-1].Y - points[i].Y) * (points[i-1].Y - points[i].Y));
        }
        lbl_len.Text = (points.Count-1) + " segments, " + (int) len + " pixels";
    }
