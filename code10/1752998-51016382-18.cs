    var Set1 = new Dictionary<string, int>();
	//Prehash all values in the set that won't be deleted from 
	for (int i = 0; i < CollectionIn.Rows.Count; i++)
	{
		string value1 = CollectionIn.Rows[i].ItemArray[0].ToString().ToLower();
		Set1.Add(value1, i);
	}
	//Loop over the other set
	for (int i2 = 0; i2 < CollectionIn2.Rows.Count; i2++)
	{
		string value2 = CollectionIn2.Rows[i2].ItemArray[0].ToString().ToLower();
		int foundIndex;
		if (Set1.TryGetValue(value2, out foundIndex) == false)
			continue;
		//Remove value1 when value1 == value2
		CollectionIn.Rows[foundIndex].Delete();
	}
	CollectionIn.AcceptChanges(); //It's probably best to save changes last as a single call
