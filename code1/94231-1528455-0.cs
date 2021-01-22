    private List<int> _CategoryIDs;
    public IList<int> CategoryIDs
    {
        get
        {
            if (_CategoryIDs == null)
            {
                _CategoryIDs = GetCommaSeparatedFieldFromDB()
                    .Split(',')
                    .Select(x => int.Parse(x))
                    .ToList();
            }
            return _CategoryIDs;
        }
    }
