            Bitmap bmp = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            g.FillRectangle(Brushes.Red, 100, 100, 100, 100);
            g.Flush();
            bmp.Save("test.png", System.Drawing.Imaging.ImageFormat.Png);
