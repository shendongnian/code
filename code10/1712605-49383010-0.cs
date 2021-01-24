    class LoggedInClient
        {
    
            public static CookieContainer LoginCookie(string user, string pass)
            {
                string sStored = "";
                string url = "http://eu.finalfantasyxiv.com/lodestone/account/login/";
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cookies = new CookieContainer();
    
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.CookieContainer = cookies;
                HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(cookies.Count.ToString());
                string sPage = "";
                using (var vPage = new StreamReader(response1.GetResponseStream()))
                {
                    sPage = vPage.ReadToEnd();
                }
    
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(sPage);
                sStored = doc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='_STORED_']").Attributes["value"].Value;
                string param = "sqexid="+user+"8&password="+pass+"&_STORED_=" + sStored;
                string postURL = doc.DocumentNode.SelectSingleNode("//form[@name='mainForm']").Attributes["action"].Value;
                //Console.WriteLine(sStored);
                postURL = "https://secure.square-enix.com/oauth/oa/" + postURL;
    
                request.Method = "POST";
                byte[] paramAsBytes = Encoding.Default.GetBytes(param);
    
                request = (HttpWebRequest)WebRequest.Create(postURL);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = false;
                try
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(paramAsBytes, 0, paramAsBytes.Length);
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                }
    
                string sGETPage = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var vPage = new StreamReader(response.GetResponseStream()))
                    {
                        sPage = vPage.ReadToEnd();
                        sGETPage = response.Headers["Location"];
                    }
    
                }
    
               // Console.WriteLine(sPage);
                request = (HttpWebRequest)WebRequest.Create(sGETPage);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.CookieContainer = cookies;
                HttpWebResponse response2 = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(cookies.Count.ToString());
                sPage = "";
                using (var vPage = new StreamReader(response2.GetResponseStream()))
                {
                    sPage = vPage.ReadToEnd();
                }
    
    
               // Console.WriteLine(sPage);
    
                doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(sPage);
                string _c = doc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='_c']").Attributes["value"].Value;
                string cis_sessid = doc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='cis_sessid']").Attributes["value"].Value;
                string action = doc.DocumentNode.SelectSingleNode("//form[@name='mainForm']").Attributes["action"].Value;
                string sParams = "_c=" + _c + "&cis_sessid=" + cis_sessid;
                byte[] bData = Encoding.Default.GetBytes(sParams);
    
    
    
               // Console.WriteLine(sStored);
                request = (HttpWebRequest)WebRequest.Create(action);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = true;
    
                try
                {
    
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(bData, 0, bData.Length);
                    }
    
                }
    
                catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                }
    
                string nextPage = "";
    
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
    
                    using (var vPage = new StreamReader(response.GetResponseStream()))
                    {
                        nextPage = vPage.ReadToEnd();
                    }
    
                }
    
              //  Console.WriteLine(nextPage);
    
                doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(nextPage);
                string csrf_token = doc.DocumentNode.SelectSingleNode("//input[@type='hidden' and @name='csrf_token']").Attributes["value"].Value;
                string cicuid = "51624738";
    
                string timestamp = Convert.ToInt32(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString() + "100";
                action = "http://eu.finalfantasyxiv.com/lodestone/api/account/select_character/";
                sParams = "csrf_token=" + csrf_token + "&cicuid=" + cicuid + "&timestamp=" + timestamp;
                bData = Encoding.Default.GetBytes(sParams);
                request = (HttpWebRequest)WebRequest.Create(action);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.89 Safari/537.36";
                request.CookieContainer = cookies;
                request.AllowAutoRedirect = true;
                try
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(bData, 0, bData.Length);
                    }
                }
    
                catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                }
                nextPage = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
    
                    using (var vPage = new StreamReader(response.GetResponseStream()))
                    {
                        nextPage = vPage.ReadToEnd();
    
                    }
                }
    
              
                return cookies;
            }
        }
