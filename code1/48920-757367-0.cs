    public override bool IsReadOnly
    {
        get
        {
            return this.Attributes.Contains(ReadOnlyAttribute.Yes);
        }
    }
