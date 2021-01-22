        private bool DirectoryExists(string d)
        {
            bool IsExists = true;
            try
            {
                if (!d.EndsWith("/")) d += "/";
                d += "directoryexists.test";
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(d);
                if (nc != null) req.Credentials = new NetworkCredential(un, pw);
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                req.Timeout = 10000;
                byte[] fileContents = System.Text.Encoding.UTF8.GetBytes("SAFE TO DELETE");
                req.ContentLength = fileContents.Length;
                Stream requestStream = req.GetRequestStream();
            }
            catch (WebException ex)
            {
                IsExists = false;
            }
            return IsExists;
        }
