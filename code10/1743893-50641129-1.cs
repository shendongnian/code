        private void WebPage(string someURI) 
     { 
	    WebClient webClient = new WebClient(); 
	    string pageContent = webClient.DownloadString(someURI);
	    Console.WriteLine(pageContent);
     }
