    Dictionary<string, int> sumDict = new Dictionary<string, int>();
	foreach (var item in list) {
		if (!sumDict.ContainsKey(item.ThisName)) {
			sumDict.Add(item.ThisName, 0);
		}
		sumDict[item.ThisName] += item.ThisNumber;
	}
