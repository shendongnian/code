    WebClient wc = new WebClient();
    wc.DownloadStringAsync(new Uri("http://www.foo.com"));
    WebHeaderCollection myWebHeaderCollection = myWebClient.ResponseHeaders;
    for (int i=0; i < myWebHeaderCollection.Count; i++)				
    	Console.WriteLine ("\t" + myWebHeaderCollection.GetKey(i) + 
                           " = " + myWebHeaderCollection.Get(i));
