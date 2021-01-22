    public class Parser
    {
        Downloader download = new Downloader();
        HtmlDocument Page;
    
        public Parser(MovieTitle MovieTitle)
        {
            Page = download.FindMovie(MovieTitle);
        }
    
        public Parser(ActorName ActorName)
        {
            Page = download.FindActor(ActorName);
        }
    }
