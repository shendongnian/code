    try
    {
        SPFile destFile = projectid.RootFolder.Files.Add(destUrl, fileBytes, false);
    }
    catch (System.IO.DirectoryNotFoundException e)
    {
        try
        {
            SPFile destFile = projectid.RootFolder.Files.Add(destUrl2, fileBytes, false);
        }
        catch
        {
            // Do what you want to do.
        }
    }
    catch
    {
    }
