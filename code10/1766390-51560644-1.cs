    public class A
    {
        public int Id {get; set;}
        public string Name {get; set;}
    
        public virtual ICollection<B> Bs {get;} = new HashSet<B>();
    }
    
    
    public class B 
    {
        public int Id {get; set;}
        public string Name {get; set;}
    
        public virtual ICollection<A> As {get;} = new HashSet<A>();
    }
