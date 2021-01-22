    List<LookupItem> list;
    if (!dict.TryGetValue("Priority", out list))
    {
        // Deal with the key being missing
    }
    else
    {
        return list;
    }
