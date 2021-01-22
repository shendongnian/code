    using (System.IO.FileStream fs = new System.IO.FileStream(inputImage, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
    {
        try
        {
            using (Bitmap bitmap = (Bitmap)Image.FromStream(fs, true, false))
            {
                try
                {
                    bitmap.Save(OutputImage + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        catch (ArgumentException aex)
        {
            throw new Exception("The file received from the Map Server is not a valid jpeg image", aex);
        }
    }
