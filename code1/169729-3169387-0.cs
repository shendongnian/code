    public void ProcessRequest(HttpContext context)
    {
        string filePath = "FileSave//";
    
        //write your handler implementation here.
        if (context.Request.Files.Count <= 0)
        {
            context.Response.Write("No file uploaded");
        }
        else
        {
            for (int i = 0; i < context.Request.Files.Count; ++i)
            {
                HttpPostedFile file = context.Request.Files[i];
                file.SaveAs(context.Server.MapPath(filePath+file.FileName));
                context.Response.Write("File uploaded");
            }
        }
    }
