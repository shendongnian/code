    [Export(typeof(IRepository))]
    public class Repository : IRepository
    {
         string Param;
         [ImportingConstructor]
         public Repository(string param)
         {
             //add breakpoint
             this.Param = param;
         }
    }
