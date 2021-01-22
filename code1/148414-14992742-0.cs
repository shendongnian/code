    private List<int> _items = new List<int>();
    public IList<int> Items
    {
        get { return _items.AsReadOnly(); }
    }
}
