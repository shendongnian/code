      using System.Net;
      ...
      string address = @"http://www.gutenberg.org/files/10571/10571.txt";
      string newText = null;
      HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
      // in case you work via some kind of proxy
      request.Credentials = CredentialCache.DefaultCredentials; 
      //TODO: simplest; you way want to use Async versions
      using (var response = request.GetResponse()) {
        using (var reader = new StreamReader(response.GetResponseStream())) {
          newText = reader.ReadToEnd().ToLower();
        }
      }
