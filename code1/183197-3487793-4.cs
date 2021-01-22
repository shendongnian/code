    var flattenedRanges = new List<Range>{new Range(list.First())};
    
    foreach (var range in list.Skip(1))
    {
        // It is unclear from your question if the bounds are inclusive or exclusive at each end.
        // I have assumed that this is a [..,..] range
        if (flattenedRanges.Last().To == range.From && flattenedRanges.Last().Category == range.Category)
            flattenedRanges.Last().To = range.To;
        else
            flattenedRanges.Add(new Range(range));
    }
