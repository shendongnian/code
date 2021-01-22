            Dictionary<string, int> colStates = new Dictionary<string, int>();
            // ...
            // Some code to populate colStates dictionary
            // ...
            int OtherCount = 0;
            List<string> notRelevantKeys = new List<string>();
            foreach (string key in colStates.Keys)
            {
                double Percent = colStates[key] / colStates.Count;
                if (Percent < 0.05)
                {
                    OtherCount += colStates[key];
                    notRelevantKeys.Add(key);
                }
            }
            foreach (string key in notRelevantKeys)
            {
                colStates[key] = 0;
            }
            colStates.Add("Other", OtherCount);
