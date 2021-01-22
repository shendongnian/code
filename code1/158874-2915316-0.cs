    public Class1 Clone()
    {
        var clone = new Class1();
        clone.ImmutableProperty = this.ImmutableProperty;
        clone.MutableProperty = this.MutableProperty.Clone();
        return clone;
    }
