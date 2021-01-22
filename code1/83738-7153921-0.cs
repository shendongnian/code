    var matchedDays = days.Where(x => sampleText.Contains(x.Value));
    if (!matchedDays.Any())
    {
        // Nothing matched
    }
    else
    {
        // Get the first match
        var day = matchedDays.First();
    }
