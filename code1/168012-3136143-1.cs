    private IEnumerator<GenericItem> GetBaseEnumerator() {
      return base.GetEnumerator();
    }
    
    public new IEnumerator<SpecificItem> GetEnumerator()
    {
        IEnumerator<GenericItem> enumerator = GetBaseEnumerator();
        while (enumerator.MoveNext())
        {
            yield return (SpecificItem)enumerator.Current;
        }
    }
