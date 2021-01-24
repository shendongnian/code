    public void deltaFtpTest()
    {
        byte[] dl(string url, int offset, int limit)
        {
            using (MemoryStream fs = new MemoryStream())
            {
                FtpWebRequest oFTP = (FtpWebRequest)FtpWebRequest.Create(url);
                oFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                oFTP.UseBinary = true;
                oFTP.UsePassive = true;
                oFTP.Credentials = new NetworkCredential(@"...", "...");
                int size = 0;
                oFTP.ContentOffset = offset;
                using (FtpWebResponse response = (FtpWebResponse)oFTP.GetResponse())
                {
                    Stream responseStream = response.GetResponseStream();
                    byte[] buffer = new byte[2048];
                    int read = 0;
                    while (limit > 0)
                    {
                        read = responseStream.Read(buffer, 0, buffer.Length);
                        if (read > limit) read = limit; //if excedes limit, truncate
                        fs.Write(buffer, 0, read);
                        size += read;
                        limit -= read;
                    }
                    responseStream.Close();
                    response.Close();
                    return fs.ToArray();
                }
            }
        }
        var f = new StreamWriter(@"D:\temp\out.txt");
        var bf = new BinaryWriter(f.BaseStream);
        {
            //getting the first 10 bytes in one session
            bf.Write(dl("ftp://myserver/tmp/t1.txt", 0, 10));
            //getting the rest of the bytes. The file as 60 bytes.
            bf.Write(dl("ftp://myserver/tmp/t1.txt", 10, 50));
            bf.Close();
        }
    }
