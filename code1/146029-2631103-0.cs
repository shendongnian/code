    private void Page_Load(object sender, System.EventArgs e)
    	{
                 //Set the appropriate ContentType.
    	    Response.ContentType = "Application/pdf";
                 //Get the physical path to the file.
    	    string FilePath = MapPath("acrobat.pdf");
                 //Write the file directly to the HTTP content output stream.
    	    Response.WriteFile(FilePath);
                Response.End();
    	}
