    public ulong quantity
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
            else
            {
                this.quantity = value;
            }
        }
    }
