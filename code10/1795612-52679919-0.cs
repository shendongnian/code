    public FileResult Download()
    {
        //check payment and other condition
        //if condition not passed return null or redirect user to error view
        byte[] fileBytes = System.IO.File.ReadAllBytes(Server.Path($"\\AppData\\{fileName}"));
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
