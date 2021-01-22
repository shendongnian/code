    public string BillingAddress{
        set{
            billingAddress = value;
            firePropertyChanged("BillingAddress");
            if(string.isNullOrEmpty(ShippingAddress)
            {
                ShippingAddress = value; //use the property to ensure PropertyChanged fires
            }
        }
        get{ return billingAddress; }
    }
