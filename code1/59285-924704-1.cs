    private void respondWithFile(string filePath, string remoteFileName) 
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException(
                  string.Format("Final PDF file '{0}' was not found on disk.", 
                                 filePath));
        var fi = new FileInfo(filePath);
        Response.Clear();
        Response.AddHeader("Content-Disposition", 
                      String.Format("attachment; filename=\"{0}\"", 
                                     remoteFileName));
        Response.AddHeader("Content-Length", fi.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(fi.FullName);
        Response.End();
    }
