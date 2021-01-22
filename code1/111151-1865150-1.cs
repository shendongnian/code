    public ActionResult Download(string name)
    {
        return new DownloadResult 
           { VirtualPath = "~/files/" + name, FileDownloadName = name };
    }
