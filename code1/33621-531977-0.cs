    FtpWebRequest.fwr = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://uri"));
    fwr.ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
    fwr.ftpRequest.Credentials = new NetworkCredential("user", "pass");
    
    
    FileInfo ff = new FileInfo("localpath");
    byte[] fileContents = new byte[ff.Length];
    
    using (FileStream fr = ff.OpenRead())
    {
       fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
    }
    
    using (Stream writer = fwr.GetRequestStream())
    {
       writer.Write(fileContents, 0, fileContents.Length);
    }
    
    FtpWebResponse frp = (FtpWebResponse)fwr.GetResponse();
    Response.Write(frp.ftpResponse.StatusDescription); 
