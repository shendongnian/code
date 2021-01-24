    public ulong Quantity
    {
        get
        {
            return this.quantity;
        }
        set 
        {
            if (value == 0)
            {
                this.quantity = 1;
                return;
            }
            this.quantity = value;
        }
    }
