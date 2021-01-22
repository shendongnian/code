    foreach (var item in temptable.Rows.AsSmartEnumerable())
    {
        int index = item.Index;
        DataRow value = item.Value;
        bool isFirst = item.IsFirst;
        bool isLast = item.IsLast;
    }
