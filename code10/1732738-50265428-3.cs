    public void OnGet() {
        //...code removed for brevity
        
        Query query = new Query("StoreList")
        {
            Order = { { "Name", PropertyOrder.Types.Direction.Descending } }
        };
        IEnumerable<Entity> stores = _db.RunQuery(query).Entities;
        SportsStoreList = stores.Select(_ => new AllSportsStore {
            Name = _["Name"],
            Price = _["Price"]
        }).ToList();
    }
    
