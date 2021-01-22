        string strWebPage = "";
        // create request
        System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(sURL);
        // get response
        System.Net.HttpWebResponse objResponse;
        objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();
        // get correct charset and encoding from the server's header
        string Charset = objResponse.CharacterSet;
        Encoding encoding = Encoding.GetEncoding(Charset);
        // read response
        using (StreamReader sr = 
               new StreamReader(objResponse.GetResponseStream(), encoding))
        {
            strWebPage = sr.ReadToEnd();
            // Close and clean up the StreamReader
            sr.Close();
        }
        // Check real charset meta-tag in HTML
        int CharsetStart = strWebPage.IndexOf("charset=");
        if (CharsetStart > 0)
        {
            CharsetStart += 8;
            int CharsetEnd = strWebPage.IndexOfAny(new[] { ' ', '\"', ';' }, CharsetStart);
            string RealCharset = 
                   strWebPage.Substring(CharsetStart, CharsetEnd - CharsetStart);
            
            // real charset meta-tag in HTML differs from supplied server header???
            if(RealCharset!=Charset)
            {
                // get correct encoding
                Encoding CorrectEncoding = Encoding.GetEncoding(RealCharset);
                // read the web page again, but with correct encoding this time
                //   create request
                System.Net.WebRequest objRequest2 = System.Net.HttpWebRequest.Create(sURL);
                //   get response
                System.Net.HttpWebResponse objResponse2;
                objResponse2 = (System.Net.HttpWebResponse)objRequest2.GetResponse();
                //   read response
                using (StreamReader sr = 
                  new StreamReader(objResponse2.GetResponseStream(), CorrectEncoding))
                {
                    strWebPage = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }
            }
        }
