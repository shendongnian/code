    public IndexEntry FindHighScore(IEnumerable<IndexEntry> entries)
    {
      foreach (IndexEntry entry in entries)
      {
        IndexEntry highScore = FindHighScore(entry);
        if (highScore != null)
        {
          return highScore;
        }
      }
      return null;
    }
    
    private IndexEntry FindHighScore(IndexEntry entry)
    {
      return entry.HighScore ? entry : FindHighScore(entry.SubEntries);
    }
