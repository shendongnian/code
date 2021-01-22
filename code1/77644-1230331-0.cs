    private List<int> li;
    public ReadOnlyCollection<int> List
    {
        get { return li.AsReadOnly(); }
    }
