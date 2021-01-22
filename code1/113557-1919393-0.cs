        // GetCacheFileName -> Returns the full path of the "cached" image
        // CreateImage -> Used to create a new image if necessary
        string cacheFile = GetCacheFileName(param1, param2, param3, param4);
        if (!File.Exists(cacheFile))
        {
            Image cacheImage = CreateImage(param1, param2, param3, param4);
            cacheImage.Save(cacheFile, ImageFormat.Jpeg);
        }
        Response.ContentType = "image/jpeg";
        Response.TransmitFile(cacheFile);
