            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(xml);
            XmlNode root = doc2.DocumentElement;
            foreach (XmlNode item in root.SelectNodes(@"/rss/channel/item"))
            {
                Console.WriteLine(item.SelectSingleNode("title").FirstChild.Value);
                Console.WriteLine(item.SelectSingleNode("pubDate").FirstChild.Value);
            }
