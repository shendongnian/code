            //Executed and Tested :)            
            using (XmlReader reader = XmlReader.Create(strFeed))
            {
                rssData = SyndicationFeed.Load(reader);
                model.BlogFeed = rssData; ;
            }
            using (XmlReader reader = XmlReader.Create(strFeed1))
            {
                rssData1 = SyndicationFeed.Load(reader);
                model.BlogFeed = rssData1;
            }
            SyndicationFeed feed3 = new SyndicationFeed(rssData.Items.Union(rssData1.Items));
            model.BlogFeed = feed3;           
            return View(model);
