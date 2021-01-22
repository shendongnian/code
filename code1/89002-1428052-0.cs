    public class ProductsFactory
    {
    public static BaseProduct Create( string ProductName, Enum State)
    {
    ....
      return new ProductX;
    }
    }
    public class SailBoat: BaseProduct
    {
    public enum BoatState
    {
    Sailing,
    Docked,
    }
    }
    
    public class Airplain: BaseProduct
    {
    public enum AirplainState
    {
    Flying,
    Landing,
    TakingOff
    }
    }
    
    void main
    {
    ProductFactory.Create("SailBoat", SailBoat.BoatState.Sailing);
    ProductFactory.Create("Airplain", Airplain.AirplainState.Flying);
    }
    
    
     
