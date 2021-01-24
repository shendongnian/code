    string[] denom = new string[] { "EUR", "GBP", "EUR", "USD", "USD" };
	int[] count = new int[] { 1, 3, 4, 7, 8 };
	//Create dictionary object to manage group by denom
	Dictionary<string, int> dct = new Dictionary<string, int>();
	//Iterate and sum group by denom
	for (int i = 0; i < denom.Length; i++)
	{
		if (!dct.Keys.Contains(denom[i]))
			dct[denom[i]] = 0;
		dct[denom[i]] += count[i];
	}
	//Print output
	foreach (KeyValuePair<string, int> kpVal in dct)
		Console.WriteLine(kpVal.Key + "=" + kpVal.Value);
    dct.Clear();
