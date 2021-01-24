    public class ProductDM
    {
      private List<InventoryDM> _cabinetList = null;
      public double Min { get; set; }
      public double Max { get; set; }
      public List<InventoryDM> CabinetList
      { get
        {
          if(_cabinetList == null)
          {
            _cabinetList = ... // retrieve data from external source
          }
          return _cabinetList; 
        }
      }
    }
