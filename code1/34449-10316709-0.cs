    FtpWebRequest request = FTPProvider.GetFTPRequest(FTPProvider.Settings.FTPPath);
    public FtpWebRequest ConnectToFtp(Uri ftpServerUri)
    {
        var request = (FtpWebRequest)WebRequest.CreateDefault(ftpServerUri);
        request.Credentials = new NetworkCredential(Settings.User, Settings.Password);
        return request;
    }
    public FtpWebRequest GetFTPRequest(string filepath)
    {
        var ftpServerUri = new Uri(filepath);
        return ConnectToFtp(ftpServerUri);
    }
    public class FTPSettings
    {
        public string FTPPath;
        public string User;
        public string Password;
    }
