    using (var packageStream = new MemoryStream())
    {
        using (var fs = File.OpenRead(/* location of existing .zip */))
        {
            fs.CopyTo(packageStream);
        }
        packageStream.Position = 0;
        using (var zipPackage = new ZipArchive(packageStream, ZipArchiveMode.Update))
        {
            ... do your thing ...
        }
        return packageStream.ToArray();
    }
    
