    public class FooBat {
        public string Name { get; set; }    
        public string Label {
            get {
                 if (_label == null) 
                     _label = Name;
                 return _label;        
                }        
            set { _label = value; }    
       }
    }
