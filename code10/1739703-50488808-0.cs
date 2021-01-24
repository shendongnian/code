    try
    {
        NUnrar.Archive.RarArchive.WriteToDirectory(Sourcepath, Destination, 
            NUnrar.Common.ExtractOptions.ExtractFullPath | 
            NUnrar.Common.ExtractOptions.Overwrite);
    }
    catch (Exception e)
    {
        ExtractFile(Sourcepath, Destination);
    }
