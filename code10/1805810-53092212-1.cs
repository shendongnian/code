    foreach(var _somedata in c)
    {
        var abc = new FileData
                    {
                        _FileData = _somedata.FileData,
                        FileName = _somedata.FileName,
                    };
    
        string Img_name = abc.FileName;
        string folder_path = System.Web.HttpContext.Current.Server.MapPath("~/Images");
    
        if (!Directory.Exists(folder_path))
        {
            Directory.CreateDirectory(folder_path);
        }
    
        string imgPath = Path.Combine(folder_path, Img_name);
     
        // this call will write out all the bytes (content) of your file
        // to the file name you've specified   
        File.WriteAllBytes(imgPath, abc._FileData);
    }
