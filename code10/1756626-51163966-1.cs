    try
    {
        YourMainMethod();
    }
    catch (Exception ex)
    {
        // Handle common exceptions that you don't know when you write these codes.
    }
    void YourMainMethod()
    {
        var directory = Path.GetDirectoryName(destUrl);
        var directory2 = Path.GetDirectoryName(destUrl2);
        if (Directory.Exists(directory))
        {
            SPFile destFile = projectid.RootFolder.Files.Add(destUrl, fileBytes, false);
        }
        else if (Directory.Exists(directory2))
        {
            SPFile destFile = projectid.RootFolder.Files.Add(destUrl2, fileBytes, false);
        }
        else
        {
            // Handle the expected situations.
        }
    }
