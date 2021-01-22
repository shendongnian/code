    public void btnOneClickZip_Click(Object sender, EventArgs e)
    {
        Response.Clear();
        Response.BufferOutput = false;
    
        string archiveName = String.Format("backup-{0}.zip",
        DateTime.Now.ToString("yyyy-MM-dd-HHmmss"));
        Response.ContentType = "application/zip";
        Response.AddHeader("content-disposition", "filename=" + archiveName);
    
        using (ZipFile zip = new ZipFile())
        {
            zip.AddDirectory(Server.MapPath("~/Assets/Upload/"),
                "httpdocs/Assets/Upload");
            zip.AddDirectory(Server.MapPath("~/App_Data/"), "httpdocs/App_Data");
    
            zip.Save(Response.OutputStream);
        }
        Response.Close();
    }
