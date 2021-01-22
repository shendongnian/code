    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Color.Blue, 1.0f);
        Random rnd = new Random();
        for (int i = 0; i < Height; i++)
            g.DrawLine(pen, 0, i, Width, i);
    }
