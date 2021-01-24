    private CustomCollection<ItemClass> m_Items = new CustomCollection<ItemClass>();
    public CustomCollection<ItemClass> Items
    {
        get { return m_Items; }
        set => SetAndRaisePropertyChanged(ref m_Items, value);
    }
[...]
    Items.ChildrenPropertyChanged += Items_ChildrenPropertyChanged;
