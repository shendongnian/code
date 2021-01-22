    public void EnsureDirectoriesExist()
            {
 
                    // if the \pix directory doesn't exist - create it. 
                    if (!System.IO.Directory.Exists(Server.MapPath("~\pix")))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~\pix"));
                    }
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                    
                    if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName) == ".jpg")
                    {
                        // create posted file
                        // make sure we have a place for the file in the directory structure
                        EnsureDirectoriesExist();
                        String filePath = Server.MapPath("~\pix\" + FileUpload1.FileName);
                        FileUpload1.SaveAs(filePath);
    
                        
                    }
                    else
                    {
                        lblMessage.Text = "Not a jpg file";
                    }
                
    
            }
