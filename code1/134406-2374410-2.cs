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
