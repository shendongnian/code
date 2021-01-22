    public IEnumerable<T> GetOddStrings(
      IEnumerable<IEnumerable<string>> stringCollections)
    {
      var firstEnumerator = stringCollection.GetEnumerator();
      while(firstEnumerator.MoveNext())
      {
        var secondEnumerator = firstEnumerator.Current.GetEnumerator();
        while(secondEnumerator.MoveNext())
        { 
          var str= secondEnumerator.Current;
          if(str.Length %2 != 0) yield return str;
          if(str.Length == 42) yield break;
        }
      }
    }
