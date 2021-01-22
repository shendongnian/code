    protected bool ValidAdvert(Base item)
    {
        if (item.GetType() == typeof(Base))
            throw new ThisIsAnAbstractClassException();
        dynamic dynamicThis = this;
        return (bool)dynamicThis.ValidAdvert(item);
    }
