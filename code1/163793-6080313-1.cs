     private void RenameFileName(string currentFilename, string newFilename)
       {
           FTPSettings.IP = "DOMAIN NAME";
           FTPSettings.UserID = "USER ID";
           FTPSettings.Password = "PASSWORD";
           FtpWebRequest reqFTP = null;
           Stream ftpStream = null ;
           try
           {
    
               reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + FTPSettings.IP + "/" + currentFilename));
               reqFTP.Method = WebRequestMethods.Ftp.Rename;
               reqFTP.RenameTo = newFilename;
               reqFTP.UseBinary = true;
               reqFTP.Credentials = new NetworkCredential(FTPSettings.UserID, FTPSettings.Password);
               FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
               ftpStream = response.GetResponseStream();
               ftpStream.Close();
               response.Close();
           }
           catch (Exception ex)
           {
               if (ftpStream != null)
               {
                   ftpStream.Close();
                   ftpStream.Dispose();
               }
               throw new Exception(ex.Message.ToString());
           }
       }
    
       public static class FTPSettings
       {
           public static string IP { get; set; }
           public static string UserID { get; set; }
           public static string Password { get; set; }
       }
