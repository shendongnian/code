    new public IEnumerator GetEnumerator()
    {
    	IEnumerator ie = base.GetEnumerator();
    	while (ie.MoveNext()) {
    	    yield return Path.Combine(baseDirectory, ie.Current);
    	}
    }
