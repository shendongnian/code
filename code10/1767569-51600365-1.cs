	Dictionary<string, int> listCount = new Dictionary<string, int>();
	foreach (string item in list)
		if (!listCount.ContainsKey(item))
			listCount.Add(item, 1);
		else
			listCount[item]++;
	string result2 = "";
	foreach (KeyValuePair<string, int> item in listCount)
		result2 += item.Key + ": " + item.Value + Environment.NewLine;
	MessageBox.Show(result2);
	
