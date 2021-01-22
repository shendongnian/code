    private static string ReplaceNamedGroup(string input, string groupName, string replacement, Match m)
    {
    	string capture = m.Value;
    	capture = capture.Remove(m.Groups[groupName].Index - m.Index, m.Groups[groupName].Length);
    	capture = capture.Insert(m.Groups[groupName].Index - m.Index, replacement);
    	return capture;
    }
