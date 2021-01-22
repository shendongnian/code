    [RequiresAuthentication]
    public ActionResult Download(int clientAreaId, string fileName)
    {
        CheckRequiredFolderPermissions(clientAreaId);
        // Get the folder details for the client area
        var db = new DbDataContext();
        var clientArea = db.ClientAreas.FirstOrDefault(c => c.ID == clientAreaId);
        string decodedFileName = Server.UrlDecode(fileName);
        string virtualPath = "~/" + ConfigurationManager.AppSettings["UploadsDirectory"] + "/" + clientArea.Folder + "/" + decodedFileName;
        return new DownloadResult { VirtualPath = virtualPath, FileDownloadName = decodedFileName };
    }
