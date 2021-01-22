        for (int i = 65498; i <= 100000; i++)
        {
            using (Bitmap t = new Bitmap(800, i))
            using (Graphics gBmp = Graphics.FromImage(t))
            {
                Color green = Color.FromArgb(0x40, 0, 0xff, 0);
                using (Brush greenBrush = new SolidBrush(green))
                {
                    // draw a green rectangle to the bitmap in memory
                    gBmp.FillRectangle(greenBrush, 0, 0, 799, i);
                    if (File.Exists("c:\\temp\\i.jpg"))
                    {
                        File.Delete("c:\\temp\\i.jpg");
                    }
                    t.Save("c:\\temp\\i.jpg", ImageFormat.Jpeg);
                }
            }
            GC.Collect();
        }
