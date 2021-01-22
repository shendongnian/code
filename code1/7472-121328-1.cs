    public class Car
    {
       private Manufacturer maker;
       
       public long Id {get; set;}
       public string Maker {get {return maker.Name ; set {maker.Name = value;} }
    }
