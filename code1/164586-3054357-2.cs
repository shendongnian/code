    using System.Drawing;
    using System.Drawing.Imaging;
    public Image ConvertToGrayscale(Image image)
    {
        Image grayscaleImage = new Bitmap(image.Width, image.Height, image.PixelFormat);
        // Create the ImageAttributes object and apply the ColorMatrix
        ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
        ColorMatrix grayscaleMatrix = new ColorMatrix(new float[][]{
            new float[] {0.299f, 0.299f, 0.299f, 0, 0},
            new float[] {0.587f, 0.587f, 0.587f, 0, 0},
            new float[] {0.114f, 0.114f, 0.114f, 0, 0},
            new float[] {     0,      0,      0, 1, 0},
            new float[] {     0,      0,      0, 0, 1}
            });
        attributes.SetColorMatrix(grayscaleMatrix);
        // Use a new Graphics object from the new image.
        using (Graphics g = Graphics.FromImage(grayscaleImage))
        {
            // Draw the original image using the ImageAttributes created above.
            g.DrawImage(image,
                        new Rectangle(0, 0, grayscaleImage.Width, grayscaleImage.Height),
                        0, 0, grayscaleImage.Width, grayscaleImage.Height,
                        GraphicsUnit.Pixel,
                        attributes);
        }
        return grayscaleImage;
    }
