    private IList<BCSFilter> _BCSFilters;
    public IList<BCSFilter> BCSFilters
    {
        get
        {
            return _BCSFilters ?? (_BCSFilters = new List<BCSFilter>());
        }
        set
        {
            _BCSFilters = value;
        }
    }
