    FtpWebRequest __request = (FtpWebRequest)FtpWebRequest.Create(__requestLocation);
    __request.Method = WebRequestMethods.Ftp.ListDirectory;
    
    var __response = (FtpWebResponse)__request.GetResponse();
                            using (StreamReader __directoryList = new StreamReader(__response.GetResponseStream())) {
                                string ___line = __directoryList.ReadLine();
                                while (___line != null) {
                                    if (!String.IsNullOrEmpty(___line)) { __output.Add(___line); }
                                    ___line = __directoryList.ReadLine();
                                }
    
                                break;
                            }
