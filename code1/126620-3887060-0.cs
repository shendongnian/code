    public class RssFeedDO
    {
        public string RssFeedUrl { get; private set; }
        /// <summary>
        /// Build feed processor
        /// </summary>
        /// <param name="feedUrl">Atom or RSS url with http in front.</param>
        public RssFeedDO(string feedUrl)
        {
            this.RssFeedUrl = feedUrl;
        }
        /// <summary>
        /// Will try to get RSS data from url passed in constructor. Can do atom or rss
        /// </summary>
        /// <returns></returns>
        public SyndicationFeed GetRSSData()
        {
            SyndicationFeed feed = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.CheckCharacters = true;
            settings.CloseInput = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.DtdProcessing = DtdProcessing.Prohibit;
            if (!string.IsNullOrEmpty(this.RssFeedUrl))
            {
                using (XmlReader reader = XmlReader.Create(this.RssFeedUrl, settings))
                {
                    SyndicationFeedFormatter GenericFeedFormatter = null;
                    Atom10FeedFormatter atom = new Atom10FeedFormatter();
                    Rss20FeedFormatter rss = new Rss20FeedFormatter();
                    if (reader.ReadState == ReadState.Initial)
                    {
                        reader.MoveToContent();
                    }
                    // try either atom or rss reading
                    if (atom.CanRead(reader))
                    {
                        GenericFeedFormatter = atom;
                    }
                    if (rss.CanRead(reader))
                    {
                        GenericFeedFormatter = rss;
                    }
                    if (GenericFeedFormatter == null)
                    {
                        return null;
                    }
                    GenericFeedFormatter.ReadFrom(reader);
                    feed = GenericFeedFormatter.Feed;
                }
            }
            return feed;
        }
    }
