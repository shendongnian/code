    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.ExcludeClip(pictureBox1.Controls[0].Bounds);
        using (var b = new SolidBrush(Color.FromArgb(100, Color.Black)))
            e.Graphics.FillRectangle(b, pictureBox1.ClientRectangle);
    }
