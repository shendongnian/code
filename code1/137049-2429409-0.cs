      public class GregorianFilterCommand<T>: FilterCommand where T is IBusinessEntity
      {
         public GregorianFilterCommand(IList<T> rawDataList, .....);
    
         public IList<T> Execute();
         .........
      }
