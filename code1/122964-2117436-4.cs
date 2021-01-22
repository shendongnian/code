    public IndexEntry FindHighScore(List<IndexEntry> entries)
    {
        var highScore = GetHighScore(entries);
        if (highScore == null)
        {
            // give me only entries that contain sub-entries
            var entriesWithSub = entries.Where(e => e.SubEntries != null);
            foreach (var e in entriesWithSub)
            {
                highScore = FindHighScore(e.SubEntries);
                if (highScore != null)
                    return highScore;
            }
        }
        return highScore;
    }
    private IndexEntry GetHighScore(List<IndexEntry> entries)
    {
        return entries.FirstOrDefault(IE => IE.HighScore);
    }
