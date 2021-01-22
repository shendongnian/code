    private int totalCount;
    public int TotalCount
    {
        get { return totalCount; }
        set {
                totalCount = value;
                UpdateTotalCountLabel(totalCount);
            }
    }
