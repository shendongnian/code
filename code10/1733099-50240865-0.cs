    public void DrawCircl(Point index, Bitmap img,int Radius) 
    {
        for (int i = 0; i < 360; i++)
        {
            double x = index.X - Radius * Math.Cos(2 * Math.PI / 360 * i);
            double y = index.Y - Radius * Math.Sin(2 * Math.PI / 360 * i);
            img.SetPixel((int)x, (int)y, Color.Red);
        }
    }
    //This is your image from the pictureBox1
    Bitmap img = new Bitmap(pictureBox1.Image);
    // I am targeting the middle of the image, Your case would be the binarized image
    Point index = new Point(img.Size.Width / 2, img.Size.Height / 2);
    // Calling Draw Cirle Method, the last parameter is the radius.
    DrawCircl(index,img,40);
    // After the circle been drawn you save the image where you want
    img.Save(@"[Path to Save IMG]");
