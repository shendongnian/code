     public static void UploadFtpFile(string folderName, string fileName)
        {
            FtpWebRequest request;
            try
            {
                //string folderName;
                //string fileName;
                string absoluteFileName = Path.GetFileName(fileName);
                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", "ftp.site4now.net", folderName, absoluteFileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential("Username", "Password");
                request.ConnectionGroupName = "group";
                using (FileStream fs = System.IO.File.OpenRead(fileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
