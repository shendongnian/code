    private Image RezizeImage(Image img, int maxWidth, int maxHeight)
    {
        if(img.Height < maxHeight && img.Width < maxWidth) return img;
        using (img)
        {
            Double xRatio = (double)img.Width / maxWidth;
            Double yRatio = (double)img.Height / maxHeight;
            Double ratio = Math.Max(xRatio, yRatio);
            int nnx = (int)Math.Floor(img.Width / ratio);
            int nny = (int)Math.Floor(img.Height / ratio);
            Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
            using (Graphics gr = Graphics.FromImage(cpy))
            {
                gr.Clear(Color.Transparent);
                // This is said to give best quality when resizing images
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.DrawImage(img,
                    new Rectangle(0, 0, nnx, nny),
                    new Rectangle(0, 0, img.Width, img.Height),
                    GraphicsUnit.Pixel);
            }
        }
        return cpy;
    }
    
    private MemoryStream BytearrayToStream(byte[] arr)
    {
        return new MemoryStream(arr, 0, arr.Length);
    }
    
    private void HandleImageUpload(byte[] binaryImage)
    {
        Image img = RezizeImage(Image.FromStream(BytearrayToStream(binaryImage)), 103, 32);
        img.Save("IMAGELOCATION.png", System.Drawing.Imaging.ImageFormat.Gif);
    }
