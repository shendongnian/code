    Graphics g = e.Graphics;
    Bitmap bmp = new Bitmap("sample.jpg");
    g.FillRectangle(Brushes.White, this.ClientRectangle);
    
    // Create a color matrix
    // The value 0.6 in row 4, column 4 specifies the alpha value
    float[][] matrixItems = {
                                new float[] {1, 0, 0, 0, 0},
                                new float[] {0, 1, 0, 0, 0},
                                new float[] {0, 0, 1, 0, 0},
                                new float[] {0, 0, 0, 0.6f, 0}, 
                                new float[] {0, 0, 0, 0, 1}};
    ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
    
    // Create an ImageAttributes object and set its color matrix
    ImageAttributes imageAtt = new ImageAttributes();
    imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    
    // Now draw the semitransparent bitmap image.
    g.DrawImage(bmp, this.ClientRectangle, 0.0f, 0.0f, bmp.Width, bmp.Height, 
                GraphicsUnit.Pixel, imageAtt);
    
    imageAtt.Dispose();
