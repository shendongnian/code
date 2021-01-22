    public static bool HasTwoOrMoreInEachGroup(IEnumerable<GroupSelect> enumerable)
    {
        var groups = new Dictionary<int, int>();
        foreach (GroupSelect item in enumerable)
        {
            int count = 0;
            if (groups.TryGetValue(item.GroupNo, out count))
            {
                groups[item.GroupNo] = count + 1;
            }
            else
            {
                groups.Add(item.GroupNo, 1);
            }
        }
        foreach (int count in groups.Values)
        {
            if (count <= 1)
            {
                return false;
            }
        }
        return true;
    }
