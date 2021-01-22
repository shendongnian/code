     public class FeedItem
     {
        string feedItemTitle;
        string feedItemLink;
        public string FeedItemTitle
        {
            get { return feedItemTitle; }
            set { feedItemTitle= value; }
        }
        public string FeeDItemLink
        {
            get { return feedItemLink; }
            set { feedItemLink= value; }            
        }
        public FeedItem(){}
        public FeedItem(string _feedItemTitle, string _feedItemLink)
        {
            feedItemTitle = _feedItemTitle;
            feedItemLink = _feedItemLink;
        }
     }
