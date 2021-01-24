    Bitmap bmp = new Bitmap(pictureBox1.Image);
    Graphics g = Graphics.FromImage(bmp);
    SolidBrush brush_Grey = new SolidBrush(Color.Green);
    SolidBrush brush_Gold = new SolidBrush(Color.Red);
    Rectangle rect = new Rectangle(new Point(100, 100), new Size(10, 10));
    g.FillEllipse(brush_Gold, rect);
    g.Dispose();
    pictureBox1.Image = bmp;
    pictureBox1.Image.Save(@"C:\tmpSO2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
