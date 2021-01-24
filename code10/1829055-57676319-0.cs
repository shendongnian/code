    protected void button1_click(object sender, EventArgs e)
    {
    try
    {
    string _FullName = lbFile.CommandName.ToString();
     string _FilePath = ConfigurationManager.AppSettings["SharedLocation"];
                string bucketName = ConfigurationManager.AppSettings["S3BucketName"];
    //First I am creating a file with the file name in my local machine in a shared folder
                string FileLocation = _FilePath + "\\" + _FullName;
                FileStream fs = File.Create(_FullName);
                fs.Close();
                TransferUtility fileTransferUtility = new TransferUtility();
                fileTransferUtility.Download(FileLocation, bucketName, _FullName);
                fileTransferUtility.Dispose();
                WebClient webClient = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=" + _FullName.ToString() + "");
                byte[] data = webClient.DownloadData(FileLocation);
                File.Delete(FileLocation); //After download starts, then I am deleting the file from the local path which I created initially.
                response.BinaryWrite(data);
                response.End();
    }
    }
