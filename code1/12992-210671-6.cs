    bool IsValidImage(string filename)
    {
        try
        {
            using(BitmapImage newImage = new BitmapImage(filename))
            {}
        }
        catch(NotSupportedException)
        {
            // System.NotSupportedException:
            // No imaging component suitable to complete this operation was found.
            return false;
        }
        return true;
    }
