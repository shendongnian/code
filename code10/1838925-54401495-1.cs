    [HttpPost]
    public PartialViewResult ViewImageFileList(string imageNameType)
    {
        var fileToDeletePath = Path.Combine(Server.MapPath("~/Images/NBAlogoImg/"), imageNameType);
        if (System.IO.File.Exists(fileToDeletePath))
        {
            fileOperations.Delete(fileToDeletePath);
        }
        IEnumerable<string> allImages = Directory.EnumerateFiles(Server.MapPath("~/Images/NBAlogoImg/"));
        return PartialView(allImages );
    }
    
