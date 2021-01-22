    public class Service1
    {
      public IGridResponse<T> CreateResponse<T>(IGridRequest request)
      {
        ...
        IDataForGrid<T> aa;
        if(request == 1) cg = new CustomerGridData;
        if(request == 2) og = new OrderGridData;
        var coll = aa.GetList();
      }
    }
