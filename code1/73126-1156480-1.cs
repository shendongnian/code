    private List<int> data;
    public IList<int> Data
    {
        get { return new ReadOnlyCollection<int>(this.data); }
    }
