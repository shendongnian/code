    HttpListener listener = new HttpListener(); 
    // prefix URL at which the listener will listen
    listener.Prefixes.Add("http://localhost:8080/");
    listener.Start();
    Console.WriteLine("Listening...");
    while (true)
    {
        // the GetContext method blocks while waiting for a request.
        HttpListenerContext context = listener.GetContext();
        HttpListenerRequest request = context.Request;
        // process the request
        // if you want to process request from multiple clients 
        // concurrently, use ThreadPool to run following code
        Console.WriteLine("Client IP " + request.UserHostAddress);
        Console.WriteLine("Client headers: ");
        foreach (var header in request.Headers)
        {
            Console.WriteLine(header + " " + request.Headers[header.ToString()]);
        }
        // in request.InputStream you have the data client sent
        // use context.Response to respond to client
    }
