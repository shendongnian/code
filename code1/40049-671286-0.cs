            // Cookie for our session
            var cookieContainer = new CookieContainer();
            // Encode post variables
            ASCIIEncoding encoding=new ASCIIEncoding();
            byte[] loginDataBytes = encoding.GetBytes("user_name=belaz&user_password=123");
            // Prepare our login HttpWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://blabla.fr/verify.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookieContainer;
            request.ContentLength = loginDataBytes.Length;
            
            // Write encoded post variable to the stream
            Stream newStream = request.GetRequestStream();
            newStream.Write(loginDataBytes, 0, loginDataBytes.Length);
            newStream.Close();
            // Retrieve HttpWebResponse
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Link the response cookie to the domain
            cookieContainer.Add(new Uri("http://blabla.fr/"),response.Cookies);
            // Prepare our navigate HttpWebRequest, and set his cookie.
            HttpWebRequest requestProfile = (HttpWebRequest)WebRequest.Create("http://blabla.fr/bb.php");
            requestProfile.CookieContainer = cookieContainer;
            // Retrieve HttpWebResponse
            HttpWebResponse responseProfile = (HttpWebResponse)requestProfile.GetResponse();
            // Retrieve stream response and read it to end
            Stream st = responseProfile.GetResponseStream();
            StreamReader sr = new StreamReader(st);
            string buffer = sr.ReadToEnd();
