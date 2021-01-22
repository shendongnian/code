    static bool IsJpegImage(string filename)
    {
        try
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(filename);
            return img.RawFormat == System.Drawing.Imaging.ImageFormat.Jpeg;
        }
        catch (OutOfMemoryException)
        {
            // Image.FromFile throws an OutOfMemoryException 
            // if the file does not have a valid image format or
            // GDI+ does not support the pixel format of the file.
            //
            return false;
        }
    }
