    override protected void print(PrintPageEventArgs e){
    
        System.Drawing.Image img = System.Drawing.Image.FromFile("C:\\assda.jpg");
            Point loc = new Point(100, 100);
            d.Graphics.DrawImage(img, new Rectangle(10, 20, 195, 100), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            d.Graphics.DrawString("xxxxx", new Font("Times New Romans", 14, FontStyle.Bold), Brushes.Black, new PointF(350, 60));
            }
