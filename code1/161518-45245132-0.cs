	var hashes = new Dictionary<int, string>();
	var collisions = new List<string>();
	for (int i = 0; ; ++i)
	{
		string st = i.ToString();
		int hash = st.GetHashCode();
		if (hashes.TryGetValue( hash, out string collision ))
		{
			// On .Net 4.6 we find "699391" and "1241308".
			collisions.Add( collision );
			collisions.Add( st );
			break;
		}
		else
			hashes.Add( hash, st );
	}
	Debug.Assert( collisions[0] != collisions[1], "Check we have produced two different strings" );
	Debug.Assert( collisions[0].GetHashCode() == collisions[1].GetHashCode(), "Prove we have different strings producing the same hashcode" );
	var newDictionary = new Dictionary<string, string>();
	newDictionary.Add( collisions[0], "abc" );
	newDictionary.Add( collisions[1], "def" );
	Console.Write( "If we get here without an exception being thrown, it demonstrates a dictionary accepts multiple items with different keys that produce the same hash value." );
	Debug.Assert( newDictionary[collisions[0]] == "abc" );
	Debug.Assert( newDictionary[collisions[1]] == "def" );
