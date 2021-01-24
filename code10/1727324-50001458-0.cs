    public ShopRepository(DBEntities context)
            : base(context)
    {
         ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = your_value_here;
         this._contextObject = context;
    }
