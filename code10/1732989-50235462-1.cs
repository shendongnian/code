    public class MyValue
    {
        public guid key {get;set;}
        public List<ModelOne> models {get;set;}
        public List<Guid> guids {get;set;}
    
        public void MyValue(List<ModelOne> modelsIn, List<Guid> guidsIn)
        {
            key = Guid.NewGuid();
            models = modelsIn;
            guids = guidsIn;
        }
    }
    
    public Dictionary<Guid,MyValue> Cache = new Dictionary<Guid,MyValue>(); 
    
    public List<ModelTwo> SomeMethod(MyValue valueIn)
    {
       MyValue val;
       If(Cache.TryGetValue(valueIn.Key, value)
          return Cache[valueIn.Key].models;
       else
       {
          Do Stuf...
          put in cache...
          return value;
       }
          
    }
