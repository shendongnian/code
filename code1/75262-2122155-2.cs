    public global::System.Data.Objects.ObjectQuery<Customers> Customers
    {
        get
        {
            if ((this._Customers == null))
            {
                this._Customers = base.CreateQuery<Customers>("[Customers]");
            }
            return this._Customers;
        }
    }
    private global::System.Data.Objects.ObjectQuery<Customers> _Customers;
