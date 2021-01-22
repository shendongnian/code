    class TestProgram
    {
        static void Main()
        {
            using (Image testImage = Image.FromFile(@"c:\file.bmp"))
            using (Image cropped = 
                         testImage.Crop(new Rectangle(10, 10, 100, 100)))
            {
                cropped.Save(@"c:\cropped.bmp");
            }
        }
    }
    static public class ImageExtensions
    {
        static public Bitmap Crop(this Image originalImage, Rectangle cropBounds)
        {
            Bitmap croppedImage = 
                new Bitmap(cropBounds.Width, cropBounds.Height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(originalImage,
                    0, 0,
                    cropBounds,
                    GraphicsUnit.Pixel);
            }
            return croppedImage;
        }
    }
