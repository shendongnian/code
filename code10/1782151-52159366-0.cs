    public class MainClass {
        public int Id  { get;set; }
    
        public virtual  ICollection<SubClass> SubClasses { get;set; }
    }
    
    public class SubClass {
        public int Id  { get;set; }
        [ForeignKey("MainClass")]
        public int MainClassId  { get;set; }
    
        public virtual MainClass MainClass { get;set; }
    }
