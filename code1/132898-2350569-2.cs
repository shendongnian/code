        using (Image image = Image.FromFile(@"c:\dump\myimage.jpg"))
        using (Image clone = new Bitmap(image,
            new Size(image.Size.Width / 2, image.Size.Height / 2)))
        {
            
            clone.Save(@"c:\dump\myimage2.jpg", ImageFormat.Jpeg);
        }
