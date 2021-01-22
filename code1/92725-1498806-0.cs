    foreach (SmartEnumerable<string>.Entry entry in
             new SmartEnumerable<string>(list))
    {
        Console.WriteLine ("{0,-7} {1} ({2}) {3}",
                           entry.IsLast  ? "Last ->" : "",
                           entry.Value,
                           entry.Index,
                           entry.IsFirst ? "<- First" : "");
    }
