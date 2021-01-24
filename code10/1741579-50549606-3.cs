        int GetSumOfIntBetweenTwoDateString(Dictionary<string, int> dateNumDict, string startKey, string endKey)
        {
            int sum = 0;
            if (dateNumDict.ContainsKey(startKey) && dateNumDict.ContainsKey(endKey))
            {
                List<string> keys = dateNumDict.Keys.ToList();
                int startIndex = keys.IndexOf(startKey);
                int endIndex = keys.IndexOf(endKey);
                
                for(int i = startIndex; i <= endIndex; i++)
                {
                    sum += dateNumDict[keys[i]];
                }
            }
            return sum;
        }
