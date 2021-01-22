    private void CheckTotalPrice(decimal oldPrice)
    {
        if(this.TotalPrice != oldPrice)
        {
             this.RaisePropertyChanged("TotalPrice");
        }
    }
