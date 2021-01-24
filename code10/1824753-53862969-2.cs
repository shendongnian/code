    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUploadControl.SaveAs(Server.MapPath("~/") + filename);               
            }
            catch(Exception ex)
            {
                
            }
        }
    }
