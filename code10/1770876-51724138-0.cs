    public class Natives
    {
        public string windows { get; set; }
    }
    
    public class NativesWindows
    {
        public string url { get; set; }
    }
    
    public class Classifiers
    {
        public NativesWindows __invalid_name__natives-windows { get; set; }
    }
    
    public class Downloads
    {
        public Classifiers classifiers { get; set; }
    }
    
    public class Library
    {
        public string name { get; set; }
        public Natives natives { get; set; }
        public Downloads downloads { get; set; }
    }
    
    public class RootObject
    {
        public List<Library> libraries { get; set; }
    }
