      public Collection<User> GetOnlineFriends()
      {
          Collection<string> onlineFriends = GetOnlineFriendIds();
          return GetUserInfo(StringHelper.ConvertToCommaSeparated(onlineFriends));
      }
---
       public Collection<string> GetOnlineFriendIds()
       {
           Collection<string> friendList = new Collection<string>();
           string xml = GetOnlineFriendsXML();
           if (!String.IsNullOrEmpty(xml))
           {
               XmlDocument xmlDocument = LoadXMLDocument(xml);
               XmlNodeList nodeList = xmlDocument.GetElementsByTagName("fql_query_response");
               if (nodeList != null && nodeList.Count > 0)
               {
                   XmlNodeList results = xmlDocument.GetElementsByTagName("user");
                   foreach (XmlNode node in results)
                   {
                       friendList.Add(XmlHelper.GetNodeText(node, "uid"));
                   }
               }
           }
               return friendList;
       }
