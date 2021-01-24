	var Set2 = new HashSet<string>();
	//Prehash all values in one set (ideally the larger set)
	for (int i2 = 0; i2 < CollectionIn2.Rows.Count; i2++)
	{
		string value2 = CollectionIn2.Rows[i2].ItemArray[0].ToString().ToLower();
		if (Set2.Contains(value2))
			continue; //Duplicate value
		else
			Set2.Add(value2);
	}
	//Loop over the other set
	for (int i1 = 0; i1 < CollectionIn.Rows.Count; i1++)
	{
		string value1 = CollectionIn.Rows[i1].ItemArray[0].ToString().ToLower();
		if (Set2.Contains(value1))
			continue;
		//Remove value1 when value1 == value2
		CollectionIn.Rows[i1].Delete();
	}
	CollectionIn.AcceptChanges(); //It's probably best to save changes last as a single call
