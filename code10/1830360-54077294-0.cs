    [System.Web.Services.WebMethod]
    public string UploadImage(string base64Image,string ImageName)
    {
        string path =Server.MapPath("~/images/");
		  if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
		path+=ImageName;
        byte[] fileByte = Convert.FromBase64String(base64Image);
        using (FileStream _FileStream = new FileStream(path, FileMode.Create, 
       FileAccess.Write))
        {
                    _FileStream.Write(fileByte, 0, fileByte.Length);
        }
      return "/images/"+ImageName;
    }
