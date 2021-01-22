	public IDictionary<object, object> Copy(IDictionary<TKey, TValue> source)
	{
	
	    IDictionary<object,object> targetDictionary = new Dictionary<object,object>();
	
	    foreach (KeyValuePair<TKey, TValue> sourcePair in sourceDictionary)
	    {
	         targetDictionary.Insert(sourcePair.Key, sourcePair.Value);
	    }
	
	    return targetDictionary; 
	}
	
