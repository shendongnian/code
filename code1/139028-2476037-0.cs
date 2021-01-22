    private void downloadFileAsync(string fileUrl)
            {
                string uriString;
    
                uriString = "https://ssl.rapidshare.com/cgi-bin/premiumzone.cgi";
    
                NameValueCollection postvals = new NameValueCollection();
                postvals.Add("login", "aaa");
                postvals.Add("password", "bbb");
                postvals.Add("uselandingpage", "1");
    
                WebClient myWebClient = new WebClient();
    
                Byte[] responseArray = myWebClient.UploadValues(uriString, "POST", postvals);
    
                StreamReader strRdr = new StreamReader(new MemoryStream(responseArray));
    
                string cookiestr = myWebClient.ResponseHeaders.Get("Set-Cookie");
    
                myWebClient.Headers.Add("Cookie", cookiestr);
                myWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(myClient_DownloadFileCompleted);
                myWebClient.DownloadFileAsync(new Uri("url file to download"),"C:\\Temp\\"+Path.GetFileName("url file to download"));
            }
