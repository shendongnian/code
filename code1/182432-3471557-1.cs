    [OutputCache(Duration=60, VaryByParam="*")]
    public FileResult File(string ID)
    {   
        string pathToFile;
        // Figure out file path based on ID
        return File(pathToFile, "image/jpeg");
    }
