    public static List<List<int>> SplitOnList(List<int> toSplit, List<int> splitBy)
    {
        // Argument validation omitted (check for null and Lengths are equal)
        var results = new List<List<int>>();
        var singleResult = new List<int> {toSplit[0]};
        var lastIndex = splitBy.IndexOf(toSplit[0]);
        for (int i = 1; i < toSplit.Count; i++)
        {
            var thisItem = toSplit[i];
            var thisIndex = splitBy.IndexOf(thisItem);
            if (thisIndex > lastIndex)
            {
                singleResult.Add(thisItem);
            }
            else
            {
                results.Add(singleResult);
                singleResult = new List<int> { thisItem };
            }
            lastIndex = thisIndex;
        }
        results.Add(singleResult);
        return results;
    }
