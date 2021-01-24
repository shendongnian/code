    public partial class X
    {
        public int Id { get; set; }
    
        public virtual A A { get; set; }
    
        public virtual B B { get; set; }
    }
    
    public partial class A
    {
        public A()
        {
            B = new HashSet<B>();
        }
    
        public int Id { get; set; }
    
        public virtual X X { get; set; }
    
        public virtual ICollection<B> B { get; set; }
    }
    
    public partial class B
    {
        public int Id { get; set; }
    
        public int? AId { get; set; }
    
        public virtual A A { get; set; }
    
        public virtual X X { get; set; }
    }
