    protected override void OnPaint(PaintEventArgs pea)
    {
        Graphics g = pea.Graphics;
        var rand = new Random();
    
        for (int y = 1; y <= Width; y++)
        {
            for (int x = 1; x <= Height; x++)
            {
                Color c = (Color.FromArgb(rand.Next(256),
                                          rand.Next(256),
                                          rand.Next(256)));
                using (var newPen = new Pen(c, 1))
                {
                    g.DrawRectangle(newPen, x, y, 0.5f, 0.5f);
                }
            }
        }
    }
