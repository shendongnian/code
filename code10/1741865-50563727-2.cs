    public class ProductDM
    {
      public List<InventoryDM> CabinetList { get; private set; }
      public double Min { get; set; }
      public double Max { get; set; }
      public ProductDM()
      {
        CabinetList = new List<InventoryDM>();
      }
    }
