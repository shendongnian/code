    public Order()
    {
        this._Orderlines = new EntitySet<Orderlines>(new Action<Orderline>(this.attach_Orderline), new Action<Orderline>(this.detach_Orderline));
    	OnCreated();
    }
