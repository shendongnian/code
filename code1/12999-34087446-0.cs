    try {
        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            Image im = Image.FromStream(stream);
            // Do something with image if needed.
        }
    }
    catch (ArgumentException)
    {
        if( !IsValidImageFormat(path) )
            return SetLastError("File '" + fileName + "' is not a valid image");
                                    
        throw;
    }
