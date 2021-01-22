    public class Recolor
    {
        public static Bitmap Tint(string filePath, Color c)
        {
            // load from file
            Image original = Image.FromFile(filePath);
            original = new Bitmap(original);
    
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(original);
    
            //create the ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]{
                        new float[] {0, 0, 0, 0, 0},
                        new float[] {0, 0, 0, 0, 0},
                        new float[] {0, 0, 0, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {c.R / 255.0f,
                                     c.G / 255.0f,
                                     c.B / 255.0f,
                                     0, 1}
                    });
    
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();
    
            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);
    
            //draw the original image on the new image
            //using the color matrix
            g.DrawImage(original, 
                new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height,
                GraphicsUnit.Pixel, attributes);
    
            //dispose the Graphics object
            g.Dispose();
            //return a bitmap
            return (Bitmap)original;
        }
    }
