    static void Main(string[] args)
    {
        var arr1 = new[] { "000", "110" };
        var arr2 = new[] { "111", "011", "000" };
        var arr3 = new[] { "101", "000" };
    
        var result = IsAllHaveMoreThen1SequnceDuplicate(new List<string[]> {arr1, arr2, arr3});
    }
    private static bool IsAllHaveMoreThen1SequnceDuplicate(List<string[]> arrays)
    {
        if (arrays == null || arrays.Count == 0)
        {
            return false;
        }
    
        var firstArray = arrays[0];
    
        for (var i = 1; i < arrays.Count; i++)
        {
            var isHaveMoreThen1SequnceDuplicate = IsHaveMoreThen1SequnceDuplicate(firstArray, arrays[i]);
            if (!isHaveMoreThen1SequnceDuplicate)
            {
                return false;
            }
        }
    
        return true;
    }
    private static bool IsHaveMoreThen1SequnceDuplicate(string[] arr1, string[] arr2)
    {
        var globalCounter = 0;
        foreach (var s1 in arr1)
        {
            foreach (var s2 in arr2)
            {
                var isSameSequence = IsSameSequence(s1, s2);
                if (isSameSequence)
                {
                    globalCounter++;
                    break;
                }
            }
    
            if (globalCounter == 2)
            {
                return true;
            }
        }
    
        return false;
    }
    private static bool IsSameSequence(string s1, string s2)
    {
        if (s1 == s2)
        {
            return true;
        }
    
        if (s1.Length != s2.Length)
        {
            return false;
        }
    
    
        var flags = new int[9];
        for (int i = 0; i < s1.Length; i++)
        {
            var cInt = int.Parse(s1[i].ToString());
            flags[cInt]++;
        }
    
        for (int i = 0; i < s2.Length; i++)
        {
            var cInt = int.Parse(s2[i].ToString());
            flags[cInt]--;
        }
    
        return flags.All(f => f == 0);
    }
