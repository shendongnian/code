    string fileName = ... // The name of your file
    byte[] bytes = null;
    
    if (HttpContext.Current.Cache[fileName] != null)
    {
        bytes = (byte[])HttpContext.Current.Cache[fileName];
    }
    else
    {
        bytes = ... // Retrieve your image's bytes
        HttpContext.Current.Cache[fileName] = bytes; // Set the cache
    }
    
    // Send it to the client
    Response.BinaryWrite(bytes);
    Response.Flush();
