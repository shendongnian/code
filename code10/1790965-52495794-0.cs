    HttpListener Listener = new HttpListener("http", 80);
    Listener.Start();
    HttpListenerContext ctx;
    string s;
    byte[] b;
    int i;
    
    while (true)
    {
    	ctx = Listener.GetContext();
    	Debug.Print("Serving a page...");
    	s = "";
    	for (i = 0; i < 500; i++) s += "Hello!"; // a 5KB dumb page
    	s += "";
    	b = Encoding.UTF8.GetBytes(s);
    	ctx.Response.ContentLength64 = b.Length;
    	ctx.Response.ContentType = "text/html";
    	ctx.Response.OutputStream.Write(b, 0, b.Length);
    	ctx.Response.OutputStream.Close();           
    	s = null;
    	b = null;
    	Debug.GC(true);
    	Debug.Print("Done with the page.");    
    }
