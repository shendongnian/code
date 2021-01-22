      foreach (var s in strings)
      {
          foreach (var keywordList in keywordSet) 
          {
              if (s.ContainsAll(keywordList))
              {
                  // hit!
              }
          }
      }
    ...
    private bool ContainsAll(this string s, string keywordList)
    {    
        foreach (var singleWord in keywordList.Split(' '))
        {
            if (!s.Contains(singleWord)) return false;
        }
        return true;
    }
