     protected string GetWebString(string url)
        {
            string appURL = url;
            HttpWebRequest wrWebRequest = WebRequest.Create(appURL) as HttpWebRequest;
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
    
            StreamReader srResponseReader = new StreamReader(hwrWebResponse.GetResponseStream());
            string strResponseData = srResponseReader.ReadToEnd();
            srResponseReader.Close();
            return strResponseData;
        }
