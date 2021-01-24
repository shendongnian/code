    Image up = Image.FromFile("somePath");
    Image down = Image.FromFile("anotherPath");
    using (down)
    {
        var bmp = new Bitmap(1000, 1000);
        using(var canvas = Graphics.FromImage(bmp))
        {
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvas.DrawImage(up, 0, 0);
            canvas.DrawImage(down, 0, 500);
            canvas.Save();
            pictureBox1.Image = bmp;// this line gives the error
        } 
     }
 
