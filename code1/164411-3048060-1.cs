    public interface IProduct{
       public int GetNumThings();
    }
    
    public partial class Product : IProduct{
       public int GetNumThings()
       {
       ...
       }
    }
    
    public partial class Modification: IProduct{
       public int GetNumThings()
       {
       ...
       }
    }
