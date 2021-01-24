    public FileResult ViewImage (int ImageFileItemId, 
                                 int MaxWidth, 
                                 int MaxHeight, 
                                 string FixedWidthHeight, 
                                 string JpegQuality)
    {
        bool fixed;
        if (Boolean.TryParse(FixedWidthHeight, out fixed))
        {
            // Process the request normally
            // Where the 'fixed' variable holds the parsed value
        }
        else
        {
           // Return a 404, 403, 'parameter error' or something else
        }
    }
