    public interface IMyInterface {
        IList<int> CategoryIDs {get;} // Only put get
    }
    public class MyClass : IMyInterface
    {
         List<int> categoryIDs;
         public IList<int> CategoryIDs
         {
              get { return this.categoryIDs; }
         }
    }
