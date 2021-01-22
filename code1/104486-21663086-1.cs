    private ConcurrentDictionary<string, string> items;
    private List<string> HashedListSource { get; set; }
    private List<string> HashedListTarget { get; set; }
    this.HashedListTarget.Sort();
    this.items.OrderBy(x => x.Value);
    
    private void SetDifferences()
    {
        for (int i = 0; i < this.HashedListSource.Count; i++)
        {
            if (this.HashedListTarget.BinarySearch(this.HashedListSource[i]) < 0)
            {
                this.Mismatch.Add(items.ElementAt(i).Key);
            }
        }
    }
