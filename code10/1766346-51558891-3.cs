    public static IEnumerable<int> PerformLookup(List<string> GameNames, Dictionary<string, int> GameLookup)
    {
        
          int reviewScore = 0;
          int startingEmptyGameTitle = 1;
          foreach (string element in GameNames)
          //this was missing!
          {
            if (GameLookup.ContainsKey(element))
                reviewScore = GameLookup[element];
            else
             {
               //you really need to think about what happens here if this doesn't 
               //match anything in the dictionary!
               if (GameLookup.ContainsKey($"Empty Game Title {startingEmptyGameTitle}"))
                    reviewScore = GameLookup[$"Empty Game Title {startingEmptyGameTitle}"];
                startingEmptyGameTitle++;
             }
             yield return reviewScore;
          }
     //and this!
     }
