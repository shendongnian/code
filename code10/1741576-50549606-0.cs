        void UpdateDictFromOneKeyToOtherKey(Dictionary<string, int> dateNumDict, string sourceKey, string destKey)
        {
            if(dateNumDict.ContainsKey(sourceKey))
            {
                if(dateNumDict.ContainsKey(destKey))
                {
                    dateNumDict[destKey] = dateNumDict[sourceKey];
                }
                else
                {
                    dateNumDict.Add(destKey, dateNumDict[sourceKey]);
                }
            }
        }
