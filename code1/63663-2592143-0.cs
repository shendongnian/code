        public static string TextToBase64(string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }
        public static void foobar()
        {
            var url = @"https://gmail.google.com/gmail/feed/atom";
            
            var USER = "userName";
            var PASS = "password";
            var encoded = TextToBase64(USER + ":" + PASS);
            var myWebRequest = HttpWebRequest.Create(url);
            myWebRequest.Method = "POST";
            myWebRequest.ContentLength = 0;
            myWebRequest.Headers.Add("Authorization", "Basic " + encoded);
            var response = myWebRequest.GetResponse();
            var stream = response.GetResponseStream();
            
            // Parse the stream using your favorite parsing library or using XmlDocument ... 
        }
