    int[] MagicFunction(string[] args)
    {
        return args.Select((s, i) => new { Value = s, Index = i }) // Associate an index to each item
                   .Where(o => o.Value.StartsWith("-"))            // Filter the values
                   .Select(o => o.Index)                           // Select the index
                   .ToArray();                                     // Convert to array
    }
