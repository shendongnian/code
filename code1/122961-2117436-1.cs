    var foundHighScore = myList.FirstOrDefault(IE => IE.HighScore or (IE.SubEntries != null && IE.SubEntries.Any(IES => IES.HighScore));
    var indexEntry = foundHighScore;
    if (!indexEntry.HighScore)
    {
        indexEntry = indexEntry.SubEntries.FirstOrDefault(IE => IE.HighScore);
    }
    // do something with indexEntry
