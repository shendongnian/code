    class Worker {
      private List<string> theRanks = new List<string>();
      public ICollection<string> Ranks {
        get {
          return new ReadOnlyCollection<string>(theRanks);
        }
      }
      public void AddRank(string newRank) {
        theRanks.Add(newRank);
      }
    }
