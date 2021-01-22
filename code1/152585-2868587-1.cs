    public interface IFruitManager
    {
      IEnumerable<IFruit> Fruits { get; }
      
      void Delete(IFruit);
    }
    
    public class FruitManager : IFruitManager
    {
       public FruitManager(IEnumerable<IFruit> fruits)
       {
         //not implemented
       }
    
       public IEnumerable<IFruit> Fruits { get; private set; }
    
       public void Delete(IFruit fruit)
       {
        // not implemented
       }
    }
