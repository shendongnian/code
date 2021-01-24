    public FileResult Download(string FilePath)
    {
        DocPath = System.Web.HttpUtility.UrlDecode(FilePath);
        var comPath = HttpContext.Server.MapPath(FilePath);
        byte[] fileBytes = System.IO.File.ReadAllBytes(comPath);
        string fileName = Path.GetFileName(comPath);
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
