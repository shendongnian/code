    Dictionary<string, string> firstDict = mainObj.information.report.FirstOrDefault();
    if (firstDict != null)
    {
        string itemFormat = "{0,-4} ";  // change the negative number to change the column width
        // write out the headers by getting the keys from the first dictionary
        foreach (string key in firstDict.Keys)
        {
            Console.Write(string.Format(itemFormat, key));
        }
        Console.WriteLine();
        // now write out the values for each dictionary
        foreach (Dictionary<string, string> dict in mainObj.information.report)
        {
            foreach (string value in dict.Values)
            {
                Console.Write(string.Format(itemFormat, value));
            }
            Console.WriteLine();
        }
    }
