    string[] allFileLocationsToMerge = { "filepath1", "filepath2", "..." };
	var mergedLists = new Dictionary<int, List<string>>();
	foreach (string file in allFileLocationsToMerge)
	{
		string[] allLines = File.ReadAllLines(file);
		for (int lineIndex = 0; lineIndex < allLines.Length; lineIndex++)
		{
			bool indexKnown = mergedLists.TryGetValue(lineIndex, out List<string> allLinesAtIndex);
			if (!indexKnown)
				allLinesAtIndex = new List<string>();
			allLinesAtIndex.Add(allLines[lineIndex]);
			mergedLists[lineIndex] = allLinesAtIndex;
		}
	}
	IEnumerable<string> mergeLines = mergedLists.Values.Select(list => string.Join(",", list));
	File.WriteAllLines("targetPath", mergeLines);
