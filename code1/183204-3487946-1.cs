    IEnumerable<Range> Merge(IEnumerable<Range> input)
    {
        input = input.OrderBy(r => r.Category).ThenBy(r => r.From).ThenBy(r => r.To).ToArray();
        var ignored = new HashSet<Range>();
        foreach (Range r1 in input)
        {
            if (ignored.Contains(r1))
                continue;
    
            Range tmp = r1;
            foreach (Range r2 in input)
            {
                if (tmp == r2 || ignored.Contains(r2))
                    continue;
            
                Range merged;
                if (TryMerge(tmp, r2, out merged))
                {
                    tmp = merged;
                    ignored.Add(r1);
                    ignored.Add(r2);
                }
            }
            yield return tmp;
        }
    }
    bool TryMerge(Range r1, Range r2, out Range merged)
    {
        merged = null;
        if (r1.Category != r2.Category)
            return false;
        if (r1.To + 1 < r2.From || r2.To + 1 < r1.From)
            return false;
        merged = new Range
        {
            From = Math.Min(r1.From, r2.From),
            To = Math.Max(r1.To, r2.To),
            Category = r1.Category
        };
        return true;
    }
