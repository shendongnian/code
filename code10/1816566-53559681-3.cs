    public static async Task  ListenAsync(CancellationToken token,params string[] prefixes)
    {
        if (prefixes == null || prefixes.Length == 0)
        throw new ArgumentException("prefixes");
        
        using(var listener = new HttpListener())
        {
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening. Hit any key to end.");
            //Abort if the token is signalled            
            token.Register(()=>listener.Abort());
            
            int i=0;
            //Loop until cancellation is requested
            while (!token.IsCancellationRequested)
            {
                var context = await listener.GetContextAsync();
                Console.WriteLine($"Got {i++}");
                var response = context.Response;
                string responseString = $"<HTML><BODY> Hello world {i}!</BODY></HTML>";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                using(var output = response.OutputStream)
                {
                    await output.WriteAsync(buffer,0,buffer.Length);
                }
            }
            listener.Stop();
        }
    }
