    int pos = 0;
    Dictionary<string, string> parsedResults = new Dictionary<string, string>();
    foreach (int length in new int[] { 13, 10, 8, 1, 6, 10, 15, 20, 3, 10, 6, 3, 8, 8, 1, 8, 8, 8, })
    {
        string fieldId = message.Substring(pos, 2);
        string fieldValue = message.Substring(pos + 3, length);
        parsedResults.Add(fieldId, fieldValue);
        pos += length + 3;
    }
