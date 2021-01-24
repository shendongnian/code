     if (!HttpListener.IsSupported)
        {
            Console.WriteLine("Server does not support Http Listener.");
            return;
        }
        // URI prefixes required,
        if (prefixes == null || prefixes.Length == 0)
            throw new ArgumentException("prefixes required");
        // Create a listener.
        HttpListener listener = new HttpListener();
        // Add the prefixes.
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
        Console.WriteLine("About to listen to " + prefixes[0].ToString());
        if (listener.IsListening) {
            Console.WriteLine("Currently Listening to " + prefixes[0].ToString());
        }
        //Wait until a connection is made before continuing
        //allDone.WaitOne();
        
        // Note: The GetContext method blocks while waiting for a request.
        HttpListenerContext context = listener.GetContext();
        //Retrives Username and password from the Http Request
        var hlbi = (HttpListenerBasicIdentity)context.User.Identity;
        Console.WriteLine("Username: " + hlbi.Name);
        Console.WriteLine("Password: " + hlbi.Password);
        listener.Stop();`
