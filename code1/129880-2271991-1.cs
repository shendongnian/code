    protected override void OnPaint(PaintEventArgs pea)
    {
        using (var b = new Bitmap(this.Width, this.Height))
        {
            using (var g = Graphics.FromImage(b))
            {
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
                            g.DrawRectangle(newPen, y, x, 0.5f, 0.5f);
                        }
                    }
                }
            }
    
            pea.Graphics.DrawImage(b, 0, 0);
        }
    }
-----------------------
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
                    g.DrawRectangle(newPen, y, x, 0.5f, 0.5f);
                }
            }
        }
    }y
