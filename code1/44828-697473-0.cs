    public class ClassParent  
    {  
        public string TestParent { get; set; }  
        public virtual string TestChild1 { get {return null;}}
        public virtual string TestChild2 { get {return null;}}  
    }
    
    public class ClassChild1 : ClassParent   
    {   
        public override string TestChild1 { get; set; }   
    }
    
    public class ClassChild2 : ClassParent
    {  
        public override string TestChild2 { get; set; }  
    }
