    public static IEnumerable<int> StringToIntList(string str) {
        if (String.IsNullOrEmpty(str))
            yield break;
        foreach(var s in str.Split(','))
            int num;
            if (int.TryParse(s, out num))
                yield return num;
        }
    }
