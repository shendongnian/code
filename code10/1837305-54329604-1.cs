    protected void TestButton_Clicked(object sender, EventArgs e)
    {
        //To get the file from HTML Input File
        HttpPostedFile postedFile = Request.Files["FileUpload"];
        //String your relative folder path
        string folderPath = Server.MapPath("~/FolderName/");
        //Check if your folder is exist or not, if not then created folder automatically
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        //Check did your control have image uploaded
        if (postedFile != null && postedFile.ContentLength > 0)
        {
            //To prevent duplicated name (accidently replace), using GUID code to store your image
            string GUIDCode = System.Guid.NewGuid().ToString("N");
            string filePath = folderPath + GUIDCode + ".jpg";
            postedFile.SaveAs(filePath);
        }
        else if (postedFile == null && postedFile.ContentLength <= 0)
        {
            // Do your thing when control have no image uploaded
        }
    }
