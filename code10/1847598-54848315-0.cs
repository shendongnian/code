        private String getURL(String url)
        {
            String response;
            CookieContainer jar;
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.CookieContainer = jar;
            httpWebRequest.AllowAutoRedirect = false;
            httpWebRequest.Method = "HEAD";
            httpWebRequest.CookieContainer.SetCookies(URI,webBrowser1.Document.Cookie);
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            response = httpWebResponse.GetResponseHeader("Location");
            if (response.Length == 0) response = url; //check for null String (if server din't response)
            httpWebRequest.Abort();
            return response;
        }
    
