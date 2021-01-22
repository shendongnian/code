    foreach (KeyValuePair<string, List<string>> item in dictB)
    {	
        string values = "";
        int valLen = ((List<string>)item.Value).Count;
        for (int i = 0; i < valLen; i++)
        {
            if (i == (valLen - 1))
            {
                values += item.Value[i] + "";
            }
            else
            {
                values += item.Value[i] + ", ";
            }
        }
        Console.WriteLine("Key: {0}; Values: {1};", item.Key, values);
    }
