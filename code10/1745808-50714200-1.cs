    public class MyClass
    {
        public Config Config { get;set }
    }
    
    public class Config 
    {
        public IEnumerable<Controls> controls { get;set; }
    }
    
    public class Controls
    {
        public int id { get;set }
        public string name { get;set; }
    }
