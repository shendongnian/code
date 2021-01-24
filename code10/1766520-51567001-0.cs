    static void Main(string[] args)
    {
        using (HttpListener listener = new HttpListener())
        {
            listener.Prefixes.Add(@"http://website.test.com/cookies/");
            listener.Start();
            HttpListenerContext context = listener.GetContext();
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.AddHeader("Set-Cookie", "name1=value1");
            response.AppendHeader("Set-Cookie", "name2=value2");
            response.Close();
        }
    }
