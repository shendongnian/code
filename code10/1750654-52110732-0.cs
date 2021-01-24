    public void ProcessRequest(HttpContext context)
    {
        string absolutePath = "~/your path";
        //copy to MemoryStream
        using (MemoryStream ms = new MemoryStream())
        {
            using (FileStream fs = File.OpenRead(Server.MapPath(absolutePath))) 
            { 
                fs.CopyTo(ms); 
            }
        
            //Delete file
            if(File.Exists(Server.MapPath(absolutePath)))
               File.Delete(Server.MapPath(absolutePath))
        
            //Download file
            context.Response.Clear()
            context.Response.ContentType = "image/jpg";
            context.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + absolutePath + "\"");
            context.Response.BinaryWrite(ms.ToArray())
        }
        
        Response.End();
    }
