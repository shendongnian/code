    public class Some
    {
        private readonly IOne one;
        private readonly ITwo two;
        public Some(IOne one, ITwo two)
        {
            this.one = one;
            this.two = two;
        }
        public void Work()
        {
            // Uses one and two
        }
    }
