    public static bool IsRecognisedImageFile(string fileName)
    {
        string targetExtension = System.IO.Path.GetExtension(fileName);
        if (String.IsNullOrEmpty(targetExtension))
        {
            return false;
        }
    
        var recognisedImageExtensions = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders().SelectMany(codec => codec.FilenameExtension.ToLowerInvariant().Split(';'));
    
        targetExtension = "*" + targetExtension.ToLowerInvariant();
        return recognisedImageExtensions.Contains(targetExtension);
    }
