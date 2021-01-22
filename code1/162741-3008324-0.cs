    private bool has_inited_tradevalue_linkage = false;
    public decimal TradeValue
    {
        get 
        { 
            if(!has_inited_tradevalue_linkage)
            {
                has_inited_tradevalue_linkage = true;
                this.PropertyChanged += (_, e) => 
                {
                    if(e.PropertyName.Equals("Amount") || e.PropertyName.Equals("Price"))
                        OnPropertyChanged("TradeValue");
                };
            }
            return Trade.Amount * Trade.Price; }
    }
