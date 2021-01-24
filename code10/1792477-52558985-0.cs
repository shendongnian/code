        private HttpWebRequest CreateRequest(string url, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Referer = Host;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
            request.Method = method;
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            return request;
        }
        public void Login()
        {
            byte[] bytes;
            string data;
            var SharedCookie = new CookieContainer();
            var url = "index.asp";
            
            try
            {
                //Start Session
                var request = CreateRequest(url, "GET");
                request.CookieContainer = SharedCookie;
                using (var tmpResponse = request.GetResponse())
                {
                    //WriteResponse(tmpResponse);
                    tmpResponse.Close();
                }
                //Login
                data = "password=123456";
                bytes = Encoding.UTF8.GetBytes(data);
                request = CreateRequest(url, "POST");
                request.CookieContainer = SharedCookie;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (var tmpResponse = request.GetResponse())
                {
                    //WriteResponse(tmpResponse);
                    tmpResponse.Close();
                }
                IsLoggedIn = true;
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine("Web Error:" + ex.Status);
                Console.WriteLine("Url:" + url);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Url:" + url);
                Console.WriteLine(ex.Message);
            }
        }
