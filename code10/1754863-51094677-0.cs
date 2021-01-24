    public FileResult Download(string ImageName)
    {
       
        byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(@"~/uploads/"+ImageName));
       string fileName = "myfile."+Path.GetExtension(Server.MapPath(@"~/uploads/"+ImageName));
    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
  
    }
