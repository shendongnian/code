    // from within some class with an Id and Name property
    public override string ToString() {
        return new ToStringBuilder<SomeClass>(this)
            .Append(x => x.Id)
            .Append(x => x.Name)
            .ToString();
    }
    
