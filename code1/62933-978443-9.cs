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
      
      public OddStringEnumerable(IEnumerable<IEnumerable<string>> stringCollections)
      {
        this.stringCollections = stringCollections;
      }
      
      public string Current { get; private set; }
      
      public bool MoveNext()
      {
        while(true)
        {
          switch(state)
          {
            case 0:
              firstEnumerator = this.stringCollections.GetEnumerator();
              if(!this.firstEnumerator.MoveNext()) 
              { 
                this.state = 1; 
                continue; 
              }
              
              this.secondEnumerator = this.firstEnumerator.Current;
              if(!secondEnumerator.MoveNext) continue;
              
              this.state = 2;
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
              this.state = 0;
              continue;
          }
        }
      }
    }
    
