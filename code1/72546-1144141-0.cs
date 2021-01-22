    public string GetPageContents(Uri uri) { // passed in from Request
      var client = new WebClient();
      string dirtyHtml = client.DownloadString(uri);
      string cleanedHtml = MakeReadyForEmailing(dirtyHtml); 
      return cleanedHtml;
    }
    private string MakeReadyForEmailing(string html) {
      // some implementation to replace any significant relative link 
      // with absolute links, strip javascript, etc
    }
