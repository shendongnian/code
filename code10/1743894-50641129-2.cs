       private async void WebPageAsync(string someURI)
     { 
	  WebClient webClient = new WebClient();
	  string pageContent = await webClient.DownloadStringTaskAsync(someURI); 
	  Console.WriteLine(pageContent); 
     }
