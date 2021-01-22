    using System.Net;
    using System.IO;
    using System;
    
    ...
    
    void DoIt()
    {
        String querystring = "chks=v1, v2, v3";
    
        WebRequest webrequest = HttpWebRequest.Create("http://someUrl/tst.asp");
        webrequest.ContentType = "application/x-www-form-urlencoded";
        webrequest.Method = "POST";
    
        using (Stream data = webrequest.GetRequestStream())
        {
            using (StreamWriter sw = new StreamWriter(data))
            {
                sw.Write(querystring);
            }
        }
    
        using (HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse())
        {
            if (webresponse.StatusCode == HttpStatusCode.OK)
            {
                /* post ok */
            }
        }
    }
