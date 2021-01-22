    public class BusinessProducts
    {
         private IDataContextFactory DataContextFactory { get; set; }  // my interface
         public BusinessProducts() : this(null) {}
         public BusinessProducts( IDataContextFactory factory )
         {
              this.DataContext = factory ?? new BusinessProductsDataContextFactory();
         }
         public void DoSomething()
         {
              using (DataContext dc = this.DataContextFactory().CreateDataContext())
              {
                 ...
              }
         }
