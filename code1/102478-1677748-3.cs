    public class Car : ITableDataSource
    {
      //...class implementation details...
      public IList<string> GetTableData()
      {
        return new List<string>()
        {
          this.Color,
          this.EngineSize,
          this.NumberOfSeats.ToString()
        };
      }
    }
