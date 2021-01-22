     public Shipment(DataAccessor da, string id)
     {
         _da = da;
         _id = id;
         Load();
     }
    
     protected void Load()
     {
         _listOfOrders = _da.GetOrders(_id);
     }
