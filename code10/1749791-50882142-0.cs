    public static List<Dictionary<string, object>> Merge2(List<Dictionary<string, object>> A, List<Dictionary<string, object>> B) {
        var D = A.Concat(B);
    
        var temp = new Dictionary<string, Dictionary<string, object>>();
    
        foreach (var d in D) {
            var key = (string)d["X"];
            if (temp.ContainsKey(key))
                foreach (var kv in d)
                    temp[key][kv.Key] = kv.Value;
            else
                temp[key] = new Dictionary<string, object>(d);
        }
    
        return new List<Dictionary<string, object>>(temp.Values);
    }
