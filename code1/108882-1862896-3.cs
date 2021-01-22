    public static class SOExtensions
    {
        public static int Rank(this SyndicationItem item)
        {
            return item.ElementExtensions
                       .ReadElementExtensions<int>("rank", "http://purl.org/atompub/rank/1.0")
                       .FirstOrDefault();
        }
    }
