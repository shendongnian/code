    ...
    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(address);
    ftpRequest.Credentials = new NetworkCredential(username, password);
    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    ftpRequest.KeepAlive = false;
    
    FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
    
    sr = new StreamReader(ftpResponse.GetResponseStream());
    sw = new StreamWriter(new FileStream(fileName, FileMode.Create));
    
    sw.WriteLine(sr.ReadToEnd());
    sw.Close();
    
    ftpResponse.Close();
    sr.Close();
    ...
