     public class CustomerTransactionViewModel : IViewModel
    {
        public int CustomerTransactionId{ get; set; },
        public string ProductName {get; set; }, //joins to ProductTypeTable
        public string ProductDescription {get; set; }, 
        public string StatusName {get; set; },  //joins to StatusTable
        public string DateOfPurchase{ get; set; },
        public int PurchaseAmount { get; set; },
      // Every view model should always have mapper from dbmodel to vm.
      private void MaptoEntity(Entity e)
      {
        this.CustomerTransactionId = e.ID
        .....
        // this is also a repository that mapping db to view model.
        var prod = new ProductTypeViewModel().Load(e.ProductID);
        this.ProductName = prod.ProductName;
        this.ProductDescription = prod.ProductDescription;
        // so on.......
      }
      public bool Load(int id)
      {
       // Call data from DB.
        var entity = dbcontext.Entity.Find(id);
       // Map you from DB.
        this.MaptoEntity(entity)
      }
    }
