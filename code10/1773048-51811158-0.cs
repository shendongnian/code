    public class A
    {
        [InverseProperty("As")]
        public ICollection<B> Bs { get; set; }
    }
    
    public class B
    {
        [InverseProperty("Bs")]
        public ICollection<A> As { get; set; }
    }
