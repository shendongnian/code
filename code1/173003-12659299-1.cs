    HttpListener listener = new HttpListener();
    listener.Prefixes.Add("http://+/PublicIP/");
    listener.Start();
    while (true)
    {
        HttpListenerContext context = listener.GetContext();
        string clientIP = context.Request.RemoteEndPoint.Address.ToString();
        using (Stream response = context.Response.OutputStream)
        using (StreamWriter writer = new StreamWriter(response))
            writer.Write(clientIP);
    
        context.Response.Close();
    }
