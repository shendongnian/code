    [EditableRadioListAttribute(Title = "Item")]
    public virtual string Item
    {
        get { return (string)(GetDetail("Item", "")); }
        set { SetDetail("Item", value, ""); }
    }
