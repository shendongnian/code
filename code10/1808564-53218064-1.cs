    public class MovieLink
    {
        public MovieLink() { }
        public int Hash { get; set; }
        public string VideoLink { get; set; }
        public string ImageLink { get; set; }
    }
    List<MovieLink> MoviesLinks = new List<MovieLink>();
    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        if (webBrowser1.ReadyState != WebBrowserReadyState.Complete) return;
        var DocumentFrames = webBrowser1.Document.Window.Frames;
        foreach (HtmlWindow Frame in DocumentFrames)
        {
            try
            {
                var VideoElement = 
                    Frame.Document.Body
                         .GetElementsByTagName("VIDEO").Cast<HtmlElement>().First();
                if (VideoElement != null)
                {
                    string VideoLink = VideoElement.Children[0].GetAttribute("src");
                    int Hash = VideoLink.GetHashCode();
                    if (MoviesLinks.Any(m => m.Hash == Hash))
                    {
                        //Done parsing this URL: 
                        //remove handler of whatever else is planned to move to the next site/page
                        return;
                    }
  
                    string SourceImage = VideoElement.GetAttribute("poster");
                    MoviesLinks.Add(new MovieLink() {
                        Hash = Hash, VideoLink = VideoLink, ImageLink = SourceImage
                    });
                 }
            }
            catch (UnauthorizedAccessException) { }
            catch (InvalidOperationException) { }
        }
    }
