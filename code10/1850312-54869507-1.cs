        Bitmap bmp = new Bitmap(10, 12);
        using (Graphics g = Graphics.FromImage(bmp))
        using (SolidBrush b1 = new SolidBrush(Color.ForestGreen))
        using (SolidBrush b2 = new SolidBrush(Color.Maroon))
        {
            g.Clear(Color.Silver);
            g.FillRectangle(b1, 0, 3, 10, 4);
            g.FillRectangle(b2, 0, 9, 10, 3);
            chart1.Images.Add(new NamedImage("tile3cols", bmp));
        }
