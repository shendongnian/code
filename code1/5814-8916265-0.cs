        [TestMethod]
        public void ShouldCombineRssFeeds()
        {
            //reference: http://stackoverflow.com/questions/79197/combining-two-syndicationfeeds
            SyndicationFeed feed;
            SyndicationFeed feed2;
            var feedUri = new Uri("http://stackoverflow.com/feeds/tag/silverlight");
            using(var reader = XmlReader.Create(feedUri.AbsoluteUri))
            {
                feed = SyndicationFeed.Load(reader);
            }
            Assert.IsTrue(feed.Items.Count() > 0, "The expected feed items are not here.");
            var feed2Uri = new Uri("http://stackoverflow.com/feeds/tag/wpf");
            using(var reader2 = XmlReader.Create(feed2Uri.AbsoluteUri))
            {
                feed2 = SyndicationFeed.Load(reader2);
            }
            Assert.IsTrue(feed2.Items.Count() > 0, "The expected feed items are not here.");
            var feedsCombined = new SyndicationFeed(feed.Items.Union(feed2.Items));
            Assert.IsTrue(
                feedsCombined.Items.Count() == feed.Items.Count() + feed2.Items.Count(),
                "The expected number of combined feed items are not here.");
            var builder = new StringBuilder();
            using(var writer = XmlWriter.Create(builder))
            {
                feedsCombined.SaveAsRss20(writer);
                writer.Flush();
                writer.Close();
            }
            var xmlString = builder.ToString();
            Assert.IsTrue(new Func<bool>(
                () =>
                {
                    var test = false;
                    var xDoc = XDocument.Parse(xmlString);
                    var count = xDoc.Root.Element("channel").Elements("item").Count();
                    test = (count == feedsCombined.Items.Count());
                    return test;
                }
            ).Invoke(), "The expected number of RSS items are not here.");
        }
