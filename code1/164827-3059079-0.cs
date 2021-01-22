    using System.ServiceModel.Syndication;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            using(XmlReader source = XmlReader.Create(
                     "http://forgefx.blogspot.com/feeds/posts/default")) {
                int count = SyndicationFeed.Load(source).Items.Count();
            }
        }
    }
