    bool IsValidImage(string filename)
    {
        try
        {
            using(Image newImage = Image.FromFile(filename))
            {}
        }
        catch (OutOfMemoryException ex)
        {
            //The file does not have a valid image format.
            //-or- GDI+ does not support the pixel format of the file
    
            return false;
        }
        return true;
    }
