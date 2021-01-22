    public void MergeImages(string FirstFileName, string SecondFileName)
    {
        Image firstImg = Image.FromFile(@"C:\temp\pic1.jpg");
        Image secondImg = Image.FromFile(@"C:\temp\pic2.jpg");
        Bitmap im1 = new Bitmap(firstImg);
        Bitmap im2 = new Bitmap(secondImg);
        Bitmap result = new Bitmap(im1.Width + im2.Width, (im1.Height > im2.Height) ? im1.Height : im2.Height);
        Graphics gr = Graphics.FromImage(result);
        gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
        gr.DrawImage(firstImg, 0, 0);
        gr.DrawImage(secondImg, im1.Width + 1, 0);
        gr.Save();
        result.Save(@"C:\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    }
