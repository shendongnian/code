    public IEnumerable<T> GetOddStrings(
      IEnumerable<IEnumerable<string>> stringCollections)
    {
      return new OddStringEnumerable(stringCollections);
    }
    
    private class OddStringEnumerable : IEnumerable<string>
    {
      IEnumerable<IEnumerable<string>> stringCollections;
      IEnumerator<IEnumerable<string>> firstEnumerator;
      IEnumerator<string> secondEnumerator;
      string str;
      int state;
      
      public string Current { get; private set; }
      
      public bool MoveNext()
      {
        while(1)
        {
          switch(state)
          {
            case 0:
              firstEnumerator = stringCollection.GetEnumerator();
              if(!firstEnumerator.MoveNext()) 
              { 
                state = 1; 
                continue; 
              }
              
              secondEnumerator = firstEnumerator.Current;
              if(!secondEnumerator.MoveNext) continue;
              
              state = 2;
              if(str.Length %2 != 0) 
              {
                this.Current = str;
                return true;
              }
              continue;
            case 1:
              return false;
            case 2:
              if(str.Length == 42) return false;
              state = 0;
              continue;
          }
        }
      }
    }
    
