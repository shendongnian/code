    foreach(string item in TempFilesList)
    {
      string path = String.Format("{0}/temp/{1}", HttpContext.Current.Application["baseWebDomainUrl"], item);
      File.Delete(Server.MapPath(path));
    }
