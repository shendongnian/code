    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = false;
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "attachment; filename=pauls_chapel_audio.zip");
    
        using (ZipFile zip = new ZipFile())
        {
            zip.CompressionLevel = CompressionLevel.None;
            zip.AddSelectedFiles("*.mp3", Server.MapPath("~/content/audio/"), "", false);
            zip.Save(Response.OutputStream);
        }
    
        Response.Close();
    }
    
    
