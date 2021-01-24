     public async Task Process(Action ProcessFinished)
     {
        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        session_Data[2] = unixTimestamp.ToString();
        try
        {
            string url = "";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(url);
            IWebProxy proxy = request1.Proxy;
            if (proxy != null)
            {
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(request1.RequestUri));
            }
            else
            {
                Console.WriteLine("Proxy is null; no proxy will be used");
            }
            WebProxy myProxy = new WebProxy();
            Uri newUri = new Uri("http://" + ip + ":" + port);
            // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
            myProxy.Address = newUri;
            // Create a NetworkCredential object and associate it with the 
            // Proxy property of request object.
            myProxy.Credentials = new NetworkCredential(user, pass);
            request1.Proxy = myProxy;
            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "{\"device\"}";
            byte[] data = Encoding.GetEncoding("UTF-8").GetBytes(postData);
            WebRequest request = request1;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            Console.WriteLine(sr.ReadToEnd());
            JObject session = JObject.Parse(sr.ReadToEnd());
            sr.Close();
            stream.Close();
        }
        catch (Exception ex)
        {
            this.Error = ex.Message;
        }
    }
    public static void ProcessFinished()
    {
       //Do some work after each request
    }
    for(var i=0; i<5; i++)
    {
       await Process(ProcessFinished);
    }
