            string loginUri = "http://www.someaddress.com/wp-login.php";
            string username = "username";
            string password = "pass";
            string reqString = "log=" + username + "&pwd=" + password;
            byte[] requestData = Encoding.UTF8.GetBytes(reqString);
            CookieContainer cc = new CookieContainer();
            var request = (HttpWebRequest)WebRequest.Create(loginUri);
            request.Proxy = null;
            request.AllowAutoRedirect = false;
            request.CookieContainer = cc;
            request.Method = "post";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = requestData.Length;
            using (Stream s = request.GetRequestStream())
                s.Write(requestData, 0, requestData.Length);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie c in response.Cookies)
                    Console.WriteLine(c.Name + " = " + c.Value);
            }
            string newloginUri = "http://www.someaddress.com/private/";
            HttpWebRequest newrequest = (HttpWebRequest)WebRequest.Create(newloginUri);
            newrequest.Proxy = null;
            newrequest.CookieContainer = cc;
            using (HttpWebResponse newresponse = (HttpWebResponse)newrequest.GetResponse())
            using (Stream resSteam = newresponse.GetResponseStream())
            using (StreamReader sr = new StreamReader(resSteam))
                File.WriteAllText("private.html", sr.ReadToEnd());
            System.Diagnostics.Process.Start("private.html");
