    using System.Text;
    using System.Net;
    using System.IO;
    using System;
    
    ...
    
    void DoIt()
    {
        String querystring = "chks=v1, v2, v3";
        byte[] buffer = Encoding.UTF8.GetBytes(querystring);
    
        WebRequest webrequest = HttpWebRequest.Create("http://someUrl/tst.asp");
        webrequest.ContentType = "application/x-www-form-urlencoded";
        webrequest.Method = "POST";
        webrequest.ContentLength = buffer.Length;
    
        using (Stream data = webrequest.GetRequestStream())
        {
            data.Write(buffer, 0, buffer.Length);
        }
    
        using (HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse())
        {
            if (webresponse.StatusCode == HttpStatusCode.OK)
            {
                /* post ok */
            }
        }
    }
