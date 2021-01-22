    private ListDictionary items;
    public ListDictionary Items
        {
            get { if (items == null) {items = new ListDictionary}; return items; }
            set { items = value; }
        }
