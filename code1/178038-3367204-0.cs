        protected void Page_Load(object sender, EventArgs e)
    {
        string tempFileName = Request["tempFileName"];  // the temp file to stream
        string attachFileName = Request["attachFileName"];  // the default name for the attached file
        System.IO.FileInfo file = new System.IO.FileInfo(Path.GetTempPath() + tempFileName);
        if (!file.Exists)
        {
            pFileNotFound.Visible = true;
            lblFileName.Text = tempFileName;
        }
        else
        {
            // clear the current output content from the buffer
            Response.Clear();
            // add the header that specifies the default filename for the 
            // Download/SaveAs dialog 
            Response.AddHeader("Content-Disposition", "attachment; filename=" + attachFileName);
            // add the header that specifies the file size, so that the browser
            // can show the download progress
            Response.AddHeader("Content-Length", file.Length.ToString());
            // specify that the response is a stream that cannot be read by the
            // client and must be downloaded
            Response.ContentType = "application/octet-stream";
            // send the file stream to the client
            Response.WriteFile(file.FullName);
        }        
    }
