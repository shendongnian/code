    public Double ASortableProperty
    {
        get
        {
            if (mASortableProperty.HasValue)
            {
                return mASortableProperty.Value;
            }
            mASortableProperty = this.TryGetDoubleValue(...);
            return (mASortableProperty.HasValue ? mASortableProperty.Value : 0);
        }
    }
