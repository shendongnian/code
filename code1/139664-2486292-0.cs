    new public IEnumerator GetEnumerator()
    {
    	IEnumerator ie = base.GetEnumerator();
    	while (ie.MoveNext()) {
    	    yield return baseDirectory + ie.Current;
    	}
    }
