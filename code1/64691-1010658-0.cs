        Random r = new Random();
        int red = r.Next(0, byte.MaxValue + 1);
        int green = r.Next(0, byte.MaxValue + 1);
        int blue = r.Next(0, byte.MaxValue + 1);
        System.Drawing.Brush brush = new System.Drawing.SolidBrush(Color.FromArgb(red, green, blue));
