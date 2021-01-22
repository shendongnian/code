    public static class Helper
    {
      
      public static int GetScore(string Title, params string[] keywords)
      {
        // your routine that calcs a score based on the matchs against the Title.
      }
    }
    
    then you can use a linq statement like....
    
    var matches = from t in GetYourTitles
                  let score = Helper.GetScore(t, keywordlist)
                  where score >= 2
                  orderby score
                  select t;
