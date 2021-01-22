        public class ProcessProperties
    {
        public string PropertyName(){get; set;}
        public string PropertyValue(){get; set;}
    }
    
    
    
    public class ProcessBlock
    {
        private List<ProcessProperties> _propList;
        public List<ProcessProperties> propList(){get{return _propList;} set{this.Add(value);}}
    }
    
    ProcessBlock A = new ProcessBlock();
    ProcessProperties pp = new ProcessProperties();
    pp.PropertyName = "something";
    pp.PropertyValue = "value of something";
    A.propList = pp;
    
    ProcessBlock B = new ProcessBlock();
    ProcessProperties ppB = new ProcessProperties();
    ppB.PropertyName = "something else";
    ppB.PropertyValue = "value of something else";
    B.propList = ppB;
