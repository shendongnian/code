    public class Car
    {
        public long Id {get; set;}
        public Manufacturer Maker {private get; set;}
  
        public string ManufacturerName
        {
           get { return Maker != null ? Maker.Name : ""; }
        }
    }
    public class Manufacturer
    {
       long Id {get; set;}
       String Name {get; set;}
    }
