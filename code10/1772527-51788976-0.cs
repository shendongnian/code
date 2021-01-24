    public static class RestserviceClient
    {
        static string URL_ENDPOINT = "www.endpoint.com/service/method";
		
        public static dynamic CallService(string jsonToSend)
        {
            var url = new Uri(URL_ENDPOINT);
            var connection = (HttpWebRequest)WebRequest.Create(url);
			
			//Timeout, proxy and other configurations
            connection.Timeout = 120000;
            connection.Proxy = WebRequest.DefaultWebProxy;
            connection.KeepAlive = true;
            connection.ContentType = string.Format("application/json");
			
			//Restful call in this case POST
            connection.Method = "POST";
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			//IMPORTANT --> Add as much key-value headers you need
            connection.Headers.Add("firstHeaderKey", "firstHeader Value");
            connection.Headers.Add("secondHeaderKey", "secondHeader Value");
            using (var outStream = connection.GetRequestStream())
            {
                var docStream = new StreamWriter(outStream);
                outStream.AppendJson(jsonToSend);
                docStream.Flush();
                docStream.Close();
            }
            string retVal;
            var res = connection.GetResponse();
            using (var resStream = res.GetResponseStream())
            {
                if (resStream == null) return null;
                var reader = new StreamReader(resStream);
                retVal = reader.ReadToEnd();
            }
            return retVal;
        }
        public static void AppendJson(this Stream dos, String json)
        {
            var bld = new StringBuilder();
            bld.Append(json);
            var a = Encoding.UTF8.GetBytes(bld.ToString());
            dos.Write(a, 0, a.Length);
        }
    }
