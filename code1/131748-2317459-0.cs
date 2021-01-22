    private static string LocateFirstVolume(string filename)
    {
        var isVolume = false;
        var parts = 1u;
        using (var extractor = new SevenZipExtractor(filename))
        {
            isVolume =
                extractor.ArchiveProperties.Any(x =>
                    x.Name.Equals("IsVolume") && x.Value.Equals(true));
            parts = (
                from x in extractor.ArchiveProperties
                where x.Name.Equals("Number of volumes")
                select (uint)x.Value).DefaultIfEmpty(1u).SingleOrDefault();
        }
        if (!isVolume)
            return null;
            
        if (parts > 1)
            return filename;
        if (!Path.GetExtension(filename)
            .Equals(".rar", StringComparison.OrdinalIgnoreCase))
        {
            var rarFile = 
                Path.Combine(
                    Path.GetDirectoryName(filename), 
                    Path.GetFileNameWithoutExtension(filename) + ".rar");
            if (File.Exists(rarFile))
            {
                var firstVolume = LocateFirstVolume(rarFile);
                if (firstVolume != null)
                {
                    return firstVolume;
                }
            }
        }
        var directoryFiles = Directory.GetFiles(Path.GetDirectoryName(filename));
        foreach (var directoryFile in directoryFiles)
        {
            var firstVolume = LocateFirstVolume(directoryFile);
            
            if (firstVolume != null)
            {
                using (var extractor = new SevenZipExtractor(firstVolume))
                {
                    if (extractor.VolumeFileNames.Contains(filename))
                    {
                        return firstVolume;
                    }
                }
            }
        }
        return null;
    }
