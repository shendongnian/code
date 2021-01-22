    // get the URI
    Uri MyUrl = Request.Url; 
    // remove path because System.IO.Path doesn't like forward slashes
    string Filename = MyUrl.Segments[MyUrl.Segments.Length-1]; 
    // Extract the extension
    string Extension = System.IO.Path.GetExtension(Filename); 
