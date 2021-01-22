    public String GetHtmlPage(string strURL)
    {
        // the html retrieved from the page
        String strResult;
        WebResponse objResponse;
        WebRequest objRequest = System.Net.HttpWebRequest.Create(strURL);
        objResponse = objRequest.GetResponse();
        // the using keyword will automatically dispose the object 
        // once complete
        using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
        {
            strResult = sr.ReadToEnd();
            // Close and clean up the StreamReader
            sr.Close();
        }
        return strResult;
    }
