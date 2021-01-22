	static List<bool> ToList( this BitArray ba ) {
		List<bool> l = new List<bool>(ba.Count);
		for ( int i = 0 ; i < ba.Count ; i++ ) {
			l.Add( ba[ i ] );
		}
		return l;
	}
