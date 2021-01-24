    public partial class A
    {
        [InverseProperty("As")]
        public ICollection<A> Bs { get; set; }
    }
    
    public partial class A
    {
        [InverseProperty("Bs")]
        public ICollection<A> As { get; set; }
    }
 
