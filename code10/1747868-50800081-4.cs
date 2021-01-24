            string msg = string.Empty;
            var msgNode = node.SelectSingleNode(".//div[@class='tweet-text']");
            if (msgNode != null)
            {
                msg = msgNode.InnerText.Trim();
            }
            tweets.Add(new Tweet(msg, isRetweet));
        }
    
