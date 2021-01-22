            using (Bitmap bmp = new Bitmap(10, 10))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawLine(Pens.Black, new PointF(9.56f, 4.1f), new PointF(3.456789f, 2.12345f));
                }
                bmp.Save(@"c:\myimage.jpg", ImageFormat.Jpeg);
            }
