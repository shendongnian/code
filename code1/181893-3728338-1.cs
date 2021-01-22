    [EditableCheckBoxList(Title = "Items")]
    public virtual string Items
    {
        get { return (string)(GetDetail("Items", "")); }
        set { SetDetail("Items", value, ""); }
    }
