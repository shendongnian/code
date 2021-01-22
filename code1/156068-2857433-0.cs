    var messages = (from message in XcurrentMsg.Descendants("message")
                               where    DateTime.Parse(message.Attribute("timestamp").Value).CompareTo(DateTime.Parse(MessageCache.Last_Cached())) > 0
                               select new
                               {
                                   ip = message.Attribute("ip").Value,
                                   timestamp = message.Attribute("timestamp").Value,
                                   text = message.Value,
                               }).ToList();
