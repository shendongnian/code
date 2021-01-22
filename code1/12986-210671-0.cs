    bool IsValidImage(string filename)
    {
        try
        {
            Image newImage = Image.FromFile(filename);
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
