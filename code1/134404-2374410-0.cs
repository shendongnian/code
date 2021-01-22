      public Collection<User> GetOnlineFriends()
      {
          Collection<string> onlineFriends = GetOnlineFriendIds();
          return GetUserInfo(StringHelper.ConvertToCommaSeparated(onlineFriends));
      }
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
       public string GetOnlineFriendsXML()
       {
           Dictionary<string, string> parameterList = new Dictionary<string, string>(3);
           parameterList.Add("method", "facebook.fql.query");
           
           if (!string.IsNullOrEmpty(_userId))
           {                
               parameterList.Add("query", 
                   String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}",
                                  "SELECT uid FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1=", _userId, ") AND 'active' IN online_presence"));
           
           }
           else
           {
               throw new FacebookException("User Id is required");
           }
           return ExecuteApiCallString(parameterList, true);
       }
