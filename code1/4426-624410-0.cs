            IEnumerable<XNode> auctionNodes = Majestic12ToXml.Majestic12ToXml.ConvertNodesToXml(byteArrayOfAuctionHtml);
            foreach (XElement anchorTag in auctionNodes.OfType<XElement>().DescendantsAndSelf("a")) {
                if (anchorTag.Attribute("href") == null)
                    continue;
                Console.WriteLine(anchorTag.Attribute("href").Value);
            }
