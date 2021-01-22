    protected void Page_Load(object sender, System.EventArgs e)
    {
        //Set the appropriate ContentType.
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Pragma", "no-cache"); 
        Response.AppendHeader("Cache-Control", "no-cache");
        //Get the physical path to the file.
        string FilePath = (string)Session["fileLocation"];
        if ( FilePath != null )         
        {
            string FileName = Path.GetFileName(FilePath);
            Response.AppendHeader("Content-Disposition", "attachment; filename="+FileName);
            //Write the file directly to the HTTP content output stream.
            Response.WriteFile(FilePath);
            Response.End();
        }
    }
