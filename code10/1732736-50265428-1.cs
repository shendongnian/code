    public ActionResult MyAction() {
        Query query = new Query("StoreList")
        {
            Order = { { "Name", PropertyOrder.Types.Direction.Descending } }
        };
        IEnumerable<Entity> stores = _db.RunQuery(query).Entities;
        var model = new MyViewModel();
        model.SportsStoreList = stores.Select(_ => new AllSportsStore {
            Name = _["Name"],
            Price = _["Price"]
        }).ToList();
        
        return View(model);
    }
    
