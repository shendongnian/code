    var proxyURI = new System.Net.Uri("http://64.202.165.130:3128");
    var proxy = new System.Net.WebProxy(proxyURI);
    
    // If u need passwords:
    proxy.Credentials=new NetworkCredential(username,password);
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.stackoverflow.com");
    request.Proxy = proxy;
    }
