    public class YourClassName
    {
        public int id{ get; set; }
        public String name{ get; set; }
        public String description{ get; set; }
    }
    then
    List<YourClassName> objs = new List<YourClassName>();
    YourClassName obj = new YourClassName
    {  
      id=1,
      name = "Name",
      description = "Erika"
    };
    
    YourClassName obj2 = new YourClassName
    {  
      id = 2,
      name = "LastName",
      description = "Conor"
    };
    
    objs.Add(obj);
    objs.Add(obj1);
    var jasonSerializedObjs = new JavaScriptSerializer().Serialize(objs);
