       for (int y = 0; y < Height; y += dimensions)
       {
           e.Graphics.DrawLine(pen, 0, y, Width, y);
       }
       for (int x = 0; x < Width; x += dimensions)
       {
           e.Graphics.DrawLine(pen, x, 0, x, Height);
       }
