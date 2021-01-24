    public void AttachListener()
    {
       foreach (var product in Items)
       {
          production.PropertyChanged += OnOrderCountUpdate;
       }
    }
    
    private void OnOrderCountUpdate(object sender, PropertyChangedEventArgs e)
    {
       if(e.PropertyName == "ModelUpdateCount")
           UpdateTotalOrderValue();
    }
