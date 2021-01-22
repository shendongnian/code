    using (System.Drawing.Image src = System.Drawing.Image.FromFile("picture.jpg"))
    {
           using (Bitmap bmp = new Bitmap(320, 320))
           {
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(src, 60, 0, 240, 320);
                    bmp.Save("file.jpg", ImageFormat.Jpeg);
           }
    }
