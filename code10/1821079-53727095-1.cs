    List<string> toReplaceList = new List<string>();
                List<string> result = new List<string>();
                foreach(string test in toReplaceList)
                {
                    string temp = test;
                    foreach (KeyValuePair<string, string> kv in myDict)
                    {
                        if (temp.Contains(kv.Key))
                            temp = kv.Value(temp);
                    }
    
                    result.Add(temp);
                }
