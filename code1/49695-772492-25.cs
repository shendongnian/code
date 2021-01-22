    static bool IsJpegImage(string filename)
    {
        try
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromFile(filename)) 
            {           
                // Two image formats can be compared using the Equals method
                // See http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageformat.aspx
                //
                return img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg);
            }
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
