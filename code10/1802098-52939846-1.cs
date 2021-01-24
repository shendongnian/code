    [HttpGet]
    public ActionResult GetFiles()
    {
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\TestDirectory");
        List<FileInfo> Files = dinfo.GetFiles("*.txt").ToList();
        var model = new ViewModel();
        // use file name to generate option list
        model.FilesList = Files.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
        return PartialView("_File", model);
    }
