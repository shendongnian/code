    public static bool IsRecognisedImageFile(string fileName)
    {
        string targetExtension = System.IO.Path.GetExtension(fileName);
        if (String.IsNullOrEmpty(targetExtension))
            return false;
        else
            targetExtension = "*" + targetExtension.ToLowerInvariant();
    
        List<string> recognisedImageExtensions = new List<string>();
    
        foreach (System.Drawing.Imaging.ImageCodecInfo imageCodec in System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders())
            recognisedImageExtensions.AddRange(imageCodec.FilenameExtension.ToLowerInvariant().Split(";".ToCharArray()));
        
        foreach (string extension in recognisedImageExtensions)
        {
            if (extension.Equals(targetExtension))
            {
                return true;
            }
        }
        return false;
    }
