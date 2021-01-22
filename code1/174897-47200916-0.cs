        public static List<string> GetFtpDirectoryContents(Uri requestUri, NetworkCredential networkCredential)
        {
            var directoryContents = new List<string>(); //Create empty list to fill it later.
            //Create ftpWebRequest object with given options to get the Directory Contents. 
            var ftpWebRequest = GetFtpWebRequest(requestUri, networkCredential, WebRequestMethods.Ftp.ListDirectory);
            try
            {
                using (var ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse()) //Excute the ftpWebRequest and Get It's Response.
                using (var streamReader = new StreamReader(ftpWebResponse.GetResponseStream())) //Get list of the Directory Contentss as Stream.
                {
                    var line = string.Empty; //Initial default value for line.
                    do
                    {
                        line = streamReader.ReadLine(); //Read current line of Stream.
                        directoryContents.Add(line); //Add current line to Directory Contentss List.
                    } while (!string.IsNullOrEmpty(line)); //Keep reading while the line has value.
                }
            }
            catch (Exception) { } //Do nothing incase of Exception occurred.
            return directoryContents; //Return all list of Directory Contentss: Files/Sub Directories.
        }
        public static FtpWebRequest GetFtpWebRequest(Uri requestUri, NetworkCredential networkCredential, string method = null)
        {
            var ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUri); //Create FtpWebRequest with given Request Uri.
            ftpWebRequest.Credentials = networkCredential; //Set the Credentials of current FtpWebRequest.
            if (!string.IsNullOrEmpty(method))
                ftpWebRequest.Method = method; //Set the Method of FtpWebRequest incase it has a value.
            return ftpWebRequest; //Return the configured FtpWebRequest.
        }
        public static NetworkCredential GetNetworkCredential(string userName, string password)
        {
            //Create and Return NetworkCredential object with given UserName and Password.
            return new NetworkCredential(userName, password);
        }
