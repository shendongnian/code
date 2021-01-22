    public interface IMyInterface {
        IList<int> CategoryIDs {get;set;} 
    }
    public class MyClass : IMyInterface
    {
         List<int> categoryIDs;
         public IList<int> CategoryIDs
         {
              get { return this.categoryIDs; }
              set
              {
                    List<int> asList = value as List<int>;
                    if (asList != null)
                        this.categoryIDs = asList;
                    else
                        this.categoryIDs = new List<int>(value); // Copy values across into new list!
              }
         }
    }
