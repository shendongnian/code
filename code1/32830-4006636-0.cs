    public static class String_Ext
    {
        public static string[] SplitOnGroups(this string str, string pattern)
        {
            var matches = Regex.Matches(str, pattern);
            var partsList = new List<string>();
            for (var i = 0; i < matches.Count; i++)
            {
                var groups = matches[i].Groups;
                for (var j = 0; j < groups.Count; j++)
                {
                    var group = groups[j];
                    partsList.Add(group.Value);
                }
            }
            return partsList.ToArray();
        }
    }
    var parts = "abcde  \tfgh\tikj\r\nlmno".SplitOnGroups(@"\s+|\S+");
    for (var i = 0; i < parts.Length; i++)
        Print(i + "|" + Translate(parts[i]) + "|");
    result:
    0|abcde|
    1|  \t|
    2|fgh|
    3|\t|
    4|ikj|
    5|\r\n|
    6|lmno|
    
