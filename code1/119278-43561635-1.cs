    public ActionResult GetFile()
    {
    	string theFilename = "<Full path your file name>"; //Your actual file name
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=<file name to be shown as download>"); //optional if you want forced download
            Response.ContentType = "application/octet-stream"; //Appropriate content type based of file type
            Response.WriteFile(theFilename); //Write file to response
            Response.Flush(); //Flush contents
            Response.End(); //Complete the response
            System.IO.File.Delete(theFilename); //Delete your local file
    
            return new EmptyResult(); //return empty action result
    }
