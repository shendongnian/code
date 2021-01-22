    public IEnumerable<MyInsideArrayType> GetEnumerator()
    {
       for(int i = 0; i<this.insideArray.Count;i++)
       {
          yield return this[i];
       }
    }
