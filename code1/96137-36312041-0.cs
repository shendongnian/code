            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(yourRequestUrl);
            if (webRequest.Proxy != null)
            {
                webRequest.Proxy = null;
            }
            webRequest.KeepAlive = true;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(yourObject);
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] postBytes = encoder.GetBytes(json);
            webRequest.ContentLength = postBytes.Length;
            webRequest.CookieContainer = new CookieContainer();
            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(string.Format("{0}:{1}", userName, password)));
            webRequest.Headers.Add("Authorization", "Basic " + encoded);
            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            string result;
            using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
            {
                result = rdr.ReadToEnd();
}
