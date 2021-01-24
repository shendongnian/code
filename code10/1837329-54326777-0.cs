    lowerActionRoles.Where(entry =>
    {
        if (upperActionRoles.TryGet(entry.Key, out List<int> upperActionList))
        {
            return !upperActionList.SequenceEqual(entry.Value);
        }
        else
        {
            return false;
        }
    }
