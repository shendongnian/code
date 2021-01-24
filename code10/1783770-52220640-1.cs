    public class ClassNameBase
    {
        public int Id {get;set;}
    }
    
    public class ClassName<T> : ClassNameBase
    {
        public List<T> ObjectList { get; set; }
    }
