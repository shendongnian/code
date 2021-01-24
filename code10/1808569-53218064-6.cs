    public class MovieLink
    {
        public MovieLink() { }
        public int Hash { get; set; }
        public string VideoLink { get; set; }
        public string ImageLink { get; set; }
    }
    List<MovieLink> moviesLinks = new List<MovieLink>();
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete) return;
        var documentFrames = webBrowser1.Document.Window.Frames;
        foreach (HtmlWindow Frame in documentFrames)
        {
            try
            {
                var videoElement = 
                    Frame.Document.Body
                         .GetElementsByTagName("VIDEO").OfType<HtmlElement>().FirstOrDefault();
                if (videoElement != null)
                {
                    string videoLink = videoElement.Children[0].GetAttribute("src");
                    int hash = videoLink.GetHashCode();
                    if (moviesLinks.Any(m => m.Hash == hash))
                    {
                        // Done parsing this URL: remove handler or whatever 
                        // else is planned to move to the next site/page
                        return;
                    }
  
                    string sourceImage = videoElement.GetAttribute("poster");
                    moviesLinks.Add(new MovieLink() {
                        Hash = hash, VideoLink = videoLink, ImageLink = sourceImage
                    });
                }
            }
            catch (UnauthorizedAccessException) { } // Cannot be avoided: ignore
            catch (InvalidOperationException) { }   // Cannot be avoided: ignore
        }
    }
