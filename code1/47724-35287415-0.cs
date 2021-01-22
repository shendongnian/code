        DirectoryInfo info = new DirectoryInfo(Server.MapPath(string.Format("~/FolderName/") + txtNewmrNo.Text)); //Creating SubFolder inside the Folder with Name(which is provide by User).
        string directoryPath = info+"/".ToString();
        if (!info.Exists)  //Checking If Not Exist.
        {
            info.Create();
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++) //Checking how many files in File Upload control.
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(directoryPath + Path.GetFileName(hpf.FileName)); //Uploading Multiple Files into newly created Folder (One by One).
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This Folder already Created.');", true);
        }
