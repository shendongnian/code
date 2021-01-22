    string upload_Image(FileUpload fileupload, string ImageSavedPath)
    {
        FileUpload fu = fileupload;  
        string imagepath = "";
        if (fileupload.HasFile)
        {
            string filepath = Server.MapPath(ImageSavedPath);  
            String fileExtension = System.IO.Path.GetExtension(fu.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    try
                    {
                        string s_newfilename = DateTime.Now.Year.ToString() +
                            DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                            DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +                           DateTime.Now.Second.ToString() +  fileExtension; 
                            fu.PostedFile.SaveAs(filepath + s_newfilename);
 
                       imagepath = ImageSavedPath + s_newfilename;
                   }
                   catch (Exception ex)
                   {
                       Response.Write("File could not be uploaded.");
                   }
    
               }
    
           }
    
       }
       return imagepath;
    }
