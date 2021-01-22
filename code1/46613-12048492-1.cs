        DownLoadDocument(string strURL, string strFileName)
        {
            HttpWebRequest request;
            HttpWebResponse response = null;
            
                request = (HttpWebRequest)WebRequest.Create(strURL);
                request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                request.Timeout = 10000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                // Write to disk
                if (!Directory.Exists(myDownLoads))
                {
                    Directory.CreateDirectory(myDownLoads);
                }
                string aFilePath = myDownLoads + "\\" + strFileName;
                FileStream fs = new FileStream(aFilePath, FileMode.Create);
                byte[] read = new byte[256];
                int count = s.Read(read, 0, read.Length);
                while (count > 0)
                {
                    fs.Write(read, 0, count);
                    count = s.Read(read, 0, read.Length);
                }
                // Close everything
                fs.Close();
                s.Close();
                response.Close();
           
        }
