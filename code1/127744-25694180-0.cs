    private static void RotateAndSaveImage(string input, string output, int angle)
    {
        //Open the source image and create the bitmap for the rotatated image
        using (Bitmap sourceImage = new Bitmap(input))
        using (Bitmap rotateImage = new Bitmap(sourceImage.Width, sourceImage.Height))
        {
            //Set the resolution for the rotation image
            rotateImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            //Create a graphics object
            using (Graphics gdi = Graphics.FromImage(rotateImage))
            {
                //Rotate the image
                gdi.TranslateTransform((float)sourceImage.Width / 2, (float)sourceImage.Height / 2);
                gdi.RotateTransform(angle);
                gdi.TranslateTransform(-(float)sourceImage.Width / 2, -(float)sourceImage.Height / 2);
                gdi.DrawImage(sourceImage, new System.Drawing.Point(0, 0));
            }
    
            //Save to a file
            rotateImage.Save(output);
        }
    }
