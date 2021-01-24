    // For Class Item
    public override string ToString()
    {
       return $"Name={Name}, Duration={Duration}, Cost={Cost}";
    }
    // For Inventory Item
    public override string ToString()
    {
        return string.Join(Environment.NewLine, Items);
    }
