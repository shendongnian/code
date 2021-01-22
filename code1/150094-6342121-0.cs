    string siteUrl = "http://sn1-p1.myphone.microsoft.com/mkweb/storage/Contacts.po";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(siteUrl);
            request.CookieContainer = new CookieContainer();
            List<Cookie> cookies = new List<Cookie>();
            StreamReader sr = File.OpenText(@"c:\Users\user\AppData\Roaming\Microsoft\Windows\Cookies\user@myphone.microsoft[2].txt");
            while(!sr.EndOfStream)
            {
                string name = sr.ReadLine();
                string value = sr.ReadLine();
                string domain = sr.ReadLine();
                string capacity = sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                if(!sr.EndOfStream)
                {
                    sr.ReadLine();
                }
                var cookie = new Cookie(name, value, "/", "myphone.microsoft.com");
                cookies.Add(cookie);
            }
            foreach (var cookie in cookies)
            {
                request.CookieContainer.Add(cookie);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string tmp = reader.ReadToEnd();
            }
