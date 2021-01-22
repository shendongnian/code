    foreach (string item in TempFilesList)
    {
        path = System.Web.HttpContext.Current.Application["baseWebDomainUrl"] + "/temp/" + item;
        path = Server.MapPath(path);
        fileDel = new FileInfo(path);
        fileDel.Delete();
    }
