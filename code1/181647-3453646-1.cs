    public FavouriteElement this[int idx]
    {
        get
        {
            return (FavouriteElement)BaseGet(idx);
        }
        set
        {
          base.BaseAdd(value);
        }
    }
