    public class Parser
    {
        Downloader download = new Downloader();
        HtmlDocument Page;
    
        private Parser() { } // prevent instantiation from the outside
        public static Parser FromMovieTitle(string MovieTitle)
        {
            var newParser = new Parser();
            newParser.Page = newParser.download.FindMovie(MovieTitle);
            return newParser;
        }
    
        public static Parser FromActorName(string ActorName)
        {
            var newParser = new Parser();
            newParser.Page = newParser.download.FindActor(ActorName);
            return newParser;
        }
    }
