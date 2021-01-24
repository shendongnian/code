    public abstract class BottomClass
    {
        public abstract string NameB { get; set; }
    }
    
    public abstract class MiddleClass : BottomClass
    {
        public abstract string NameM { get; set; } 
    }
    
    public class TopClass : MiddleClass {
        public override string NameB { get; set; }
        public override string NameM { get; set; }
    }
