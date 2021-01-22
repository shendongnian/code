    private int _id;
    private List<ItemDetails> _detailItems = new List<ItemDetails>();
    public Item(int id)
    {
        _id = id;
    }
    public void AddItemDetail(ItemDetails itemDetail)
    {
        _detailItems.Add(itemDetail);
    }
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public ReadOnlyCollection<ItemDetails> DetailItems
    {
        get { return _detailItems.AsReadOnly(); }
    }
