            public IEnumerable<TwitterPosts> GetPosts()
            {
                var xmlTreeTwitter = XDocument.Load("http://twitter.com/statuses/user_timeline/#####.rss");
    
                var v = from item in xmlTreeTwitter.Descendants("rss").Elements("channel").Elements("item")
                       select new TwitterPosts
                       {
                           pubDate = item.Element("pubDate").Value,
                           Title = item.Element("title").Value,
                           Link = item.Element("link").Value
                       };
    
                return v;
            }
            public class TwitterPosts
            {
                public string pubDate { get; set; }
                public string Title { get; set; }
                public string Link { get; set; }
            }
