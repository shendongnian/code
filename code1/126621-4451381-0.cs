    public static class FeedParser
    {
        public static bool Parse(string url, ref SyndicationFeed feed)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.CheckCharacters = true;
            settings.CloseInput = true;
            settings.IgnoreComments = true;
            settings.IgnoreProcessingInstructions = true;
            settings.DtdProcessing = DtdProcessing.Prohibit;
    
            if (string.IsNullOrEmpty(url)) return false;
    
            using (XmlReader reader = XmlReader.Create(url, settings))
            {
                SyndicationFeedFormatter formatter = null;
                Atom10FeedFormatter atom_formatter = new Atom10FeedFormatter();
                Rss20FeedFormatter rss_formatter = new Rss20FeedFormatter();
    
                if (reader.ReadState == ReadState.Initial) reader.MoveToContent();
    
                if (atom_formatter.CanRead(reader)) formatter = atom_formatter;
                if (rss_formatter.CanRead(reader)) formatter = rss_formatter;
                if (formatter == null) return false;
    
                formatter.ReadFrom(reader);
                feed = formatter.Feed;
    
                return true;
            }
        }        
    }
