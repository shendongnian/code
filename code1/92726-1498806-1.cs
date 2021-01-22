    foreach (var entry in list.AsSmartEnumerable())
    {
        Console.WriteLine ("{0,-7} {1} ({2}) {3}",
                           entry.IsLast  ? "Last ->" : "",
                           entry.Value,
                           entry.Index,
                           entry.IsFirst ? "<- First" : "");
    }
