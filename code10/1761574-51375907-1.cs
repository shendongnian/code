       ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
    
                        using (ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                        {
                        using (ftpStream = ftpResponse.GetResponseStream())
                        {
    
                        using (FileStream localFileStream = new FileStream(localFile, FileMode.Create))
                        {
    
                        byte[] byteBuffer = new byte[bufferSize];
                        int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
    
                        try
                        {
                            while (bytesRead > 0)
                            {
                                localFileStream.Write(byteBuffer, 0, bytesRead);
                                bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
    
                       }
                      }
                     }
                        ftpRequest = null;
                    }
