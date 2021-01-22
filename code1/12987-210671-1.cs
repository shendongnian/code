    bool IsValidImage(string filename)
    {
        try
        {
            Image newImage = Image.FromFile(filename);
        }
        catch (OutOfMemoryException ex)
        {
            // Image.FromFile will throw this if file is invalid
            return false;
        }
        return true;
    }
