            List<string> vals = new List<string>();
            Dictionary<string, string> newDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> item in myDict)
            {
                if (!vals.Contains(item.Value))
                {
                    newDict.Add(item.Key, item.Value);
                    vals.Add(item.Value);
                }
            }
