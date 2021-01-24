    public void DoStuff()
    {
       foreach(var customer in customer.CustomerQuerys)
       {
          customer.OnProductChanged += HandleProductChanged;
       }
    }
   
    private void HandleProductChanged(object sender, DataChangedEvent args)
    {
       switch (args.Result)
       {
           case DataChangedEventFlags.ProductChanged:
              messages.Add("ProductChanged " + ((CustomerCoreData)sender).ProductName);
              break;
       }
    }
    
