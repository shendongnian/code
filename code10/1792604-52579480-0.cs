    public IEnumerator<T> GetEnumerator()
    {
    	lock (Sync)
    	 using (IEnumerator<T> safeEnum = TObjects.AsEnumerable().GetEnumerator())
    		while (safeEnum.MoveNext())
    	      yield return safeEnum.Current;
    }
