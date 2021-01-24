    var allHitsIndexes = allHits.Select((item, index) => index)
        .Where(i => allHits[i].Type == type).ToList();
    var maxCount = Math.Min(newHits.Count, allHitsIndexes.Count);
    for (var i = 0; i < maxCount; i++)
    {
        allHits[allHitsIndexes[i]] = newHits[i];
    }
