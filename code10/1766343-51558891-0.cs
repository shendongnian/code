    public static IEnumerable<int> PerformLookup(List<string> GameNames, Dictionary<string, int> GameLookup)
    {
        
          int reviewScore = 0;
          int startingEmptyGameTitle = 1;
          foreach (string element in GameNames)
          //this was missing!
          {
            if (GameLookup.ContainsKey(element))
                reviewScore = GameLookup[element]
            else
             {
               reviewScore = GameLookup["Empty Game Title " + startingEmptyGameTitle]
               startingEmptyGameTitle++;
             }
             yield return reviewScore;
          }
     //and this!
     }
