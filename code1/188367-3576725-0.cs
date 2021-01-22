    private void up(string sourceFile, string targetFile)
    {            
        try
        {
            string ftpServerIP = ConfigurationManager.AppSettings["ftpIP"];
            string ftpUserID = ConfigurationManager.AppSettings["ftpUser"];
            string ftpPassword = ConfigurationManager.AppSettings["ftpPass"];
            //string ftpURI = "";
            string filename = "ftp://" + ftpServerIP + "//" + targetFile; 
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(filename);
            ftpReq.UseBinary = true;
            ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
            ftpReq.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
    
            Byte[] b = File.ReadAllBytes(sourceFile);
    
            ftpReq.ContentLength = b.Length;
            using (Stream s = ftpReq.GetRequestStream())
            {
                s.Write(b, 0, b.Length);
            }
    
            System.Net.FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();
            MessageBox.Show(ftpResp.StatusDescription);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
