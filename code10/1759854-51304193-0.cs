    public class ABCFields
    {
    }
    
    public class XYZFields
    {
    }
    
    public class MenuEntity
    {
        public string id { get; set; }
        public string title { get; set; }
        public object link { get; set; }
        public string test { get; set; }
    }
    
    public class OPRFields
    {
        public List<MenuEntity> MenuEntity { get; set; }
    }
    
    public class RootObject
    {
        public ABCFields ABCFields { get; set; }
        public XYZFields XYZFields { get; set; }
        public OPRFields OPRFields { get; set; }
    }
