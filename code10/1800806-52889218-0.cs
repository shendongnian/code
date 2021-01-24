    Dictionary<string, string> dict = new Dictionary<string, string>() {{"10", "a"}, {"20", "b"}};
	List<KeyValuePair<string, string>> listDict = dict.ToList();
	// 1.) switch the values, last becomes first and vice-versa
	for (int i = 0; i < listDict.Count; i++)
	{
		string oppositeValue = listDict[listDict.Count - 1 - i].Value;
		dict[listDict[i].Key] = oppositeValue;
	}
	// 2.) reverse the dictionary to "switch" the keys, this is not recommended with a dictionary, because it is not an ordered collection
	dict = dict.Reverse().ToDictionary(kv => kv.Key, kv => kv.Value);
