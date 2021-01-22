    public static string Debugify<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) {
        string Result = "";
    
        if (dictionary.Count > 0) {
            StringBuilder ResultBuilder = new StringBuilder();
    
            int Counter = 0;
            foreach (KeyValuePair<TKey, TValue> Entry in dictionary) {
                Counter++;
                ResultBuilder.AppendFormat("{0}: {1}, ", Entry.Key, Entry.Value);
                if (Counter % 10 == 0) ResultBuilder.AppendLine();
            }
            Result = ResultBuilder.ToString();
        }
        return Result;
    }
