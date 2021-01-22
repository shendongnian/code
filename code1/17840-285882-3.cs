    public static string CreateUrl(Article a) {
        // Note, Article comes from Database, has properties of ArticleID, Title, etc.
        RouteValueDictionary parameters;
        string routeName = "Article"; // Set in Global.asax
        parameters 
          = new RouteValueDictionary { 
             { "id", a.ArticleID }, 
             { "title", a.Title.CleanUrl() } 
            }; 
