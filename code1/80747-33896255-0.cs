            string userIP = Request.ServerVariables["REMOTE_ADDR"];
            string localeAPIURL = "http://api.hostip.info/get_html.php?ip=" + userIP;
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(localeAPIURL);
            r.Method = "Get";
            HttpWebResponse res = (HttpWebResponse)r.GetResponse();
            Stream sr = res.GetResponseStream();
            StreamReader sre = new StreamReader(sr);
            // check response for FRANCE
            string s = sre.ReadToEnd();
            string sub = s.Substring(9, 6);
            if (sub == "FRANCE")
            {
                Response.Redirect("http://fr.mysite.com");
            }
