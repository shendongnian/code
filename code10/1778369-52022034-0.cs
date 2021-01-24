      /// button + textbox are added to the windows form, you also need to add  
      ///Using System.IO; Using System.Net; Using System.Net.Security at the very beginning...
      
     private void button1_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls11;
                  ServicePointManager.Expect100Continue = true;
            
                  string bumb = "https://nasdaq.com";
                           
                       HttpWebRequest requestHtm = (HttpWebRequest)WebRequest.Create(bumb);
                       ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                       
                   //    requestHtm.CookieContainer = new CookieContainer();
                       requestHtm.AllowAutoRedirect = true;
                       requestHtm.KeepAlive = true;
                   //    requestHtm.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                   //    requestHtm.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
                   //    requestHtm.Headers[HttpRequestHeader.AcceptLanguage] = "en-gb,en;q=0.5";
                   //    requestHtm.Headers[HttpRequestHeader.AcceptCharset] = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
                       requestHtm.Timeout = 150000;
                       //requestHtm.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:2.0) Gecko/20100101 Firefox/4.0";
                       requestHtm.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Mobile Safari/537.36";
                     //requestHtm.Method = "GET"; 
                       using (HttpWebResponse responseHtm = (HttpWebResponse)requestHtm.GetResponse())
                       {
                           StreamReader r = new StreamReader(responseHtm.GetResponseStream());
                           string text1 = r.ReadToEnd();
                         
                           textBox1.Text = text1;
                         
                       }
        }
