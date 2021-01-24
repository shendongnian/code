    public class A
    {
        [InverseProperty("As")]
        public ICollection<A> Bs { get; set; }
        [InverseProperty("Bs")]
        public ICollection<A> As { get; set; }
    }
