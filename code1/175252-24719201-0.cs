    PropertyInfo pInfo = pictureBox1.GetType().GetProperty("ImageRectangle",
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
    
    Rectangle ImRectangle = (Rectangle)pInfo.GetValue(pictureBox1, null);
    Point rTL = new Point((rectCropArea.Left - ImRectangle.Left) * pictureBox1.Image.Width / ImRectangle.Width,
                          (rectCropArea.Top - ImRectangle.Top) * pictureBox1.Image.Height / ImRectangle.Height);
    Size rSz = new Size(pictureBox1.Image.Width * rectCropArea.Width / ImRectangle.Width,
                        pictureBox1.Image.Height * rectCropArea.Height / ImRectangle.Height);
    'rect' = new Rectangle(rTL,rSz);
