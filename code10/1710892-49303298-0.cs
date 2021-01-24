    private class IndexedData
    {
        public int Sequence;
        public string Text;
    } 
    string[] data = [ "a", "a", "b" ... ]
    // Calculate "index sequence" for each data element.
    List<IndexedData> indexes = new List<IndexedData>();
    foreach (string s in data)
    {
        IndexedData last = indexes.LastOrDefault() ?? new IndexedData();
        indexes.Add(new IndexedData
        {
            Text = s,
            Sequence = (last.Text == s
                          ? last.Sequence 
                          : last.Sequence + 1)
        });
    }
    // Group by "index sequence"
    var grouped = indexes.GroupBy(i => i.Sequence)
                         .Select(g => g.Select(i => i.Text));
