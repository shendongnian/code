    private void DownloadFile()
    {
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=myFile.txt");
        Response.WriteFile(Server.MapPath("~/uploads/myFile.txt"));
        Response.Flush();	
  	    // Delete the file just before execute Response.End()
        System.IO.File.Delete(Server.MapPath("~/uploads/myFile.txt"));
        Response.End();
    }
