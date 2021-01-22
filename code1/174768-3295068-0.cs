    public class Helper
    {
      private string[] splitTitle;
      public Helper(string Title)
      {
        //split the title and store them.
      }
      
      public int GetScore(params string[] keywords)
      {
        // your routine that calcs a score based on the matchs.
      }
    }
    
    then you can use a linq statement like....
    
    var matches = from t in GetYourTitles
                  let helper = new Helper(t)
                  where helper.GetScore(keywordlist) >= 2
                  select t;
