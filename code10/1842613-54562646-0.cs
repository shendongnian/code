    public abstract class CarElement
    {
      //common properties for all car parts
      public GameObject prefab;
      public int price;
      public abstract void Equip();
    }
    [System.Serializable] //required to show full objects in inspector
    public class Chassis : CarElement
    {
        //specific properties for every car part
        public bool AWD;
        public int suspensionDepth;
        public override void Equip() { }
    }
    [System.Serializable] //required to show full objects in inspector
    public class Engine : CarElement
    {
        //specific properties for every car part
        public bool supportsAddOnExhaust;
        public int power;
        public override void Equip(){ }
    }
    public class VehicleConfig : CarPart
    {
        public Chassis[] chassis; //assigned from inspector
        public Engine[] engines;  //assigned from inspector    
        //and more car components like these two...
        //arrays because there will be multiple to chose from each type        
        public void Setup(CarElement component)
        {
              component.Equip();
              DoSomethingWithCommonVariables(component.price, component.prefab);
        }
        //method called from GUI example:
        public void MountFirstEngine()
        {
            Setup(engines[0]);
        }
    }
