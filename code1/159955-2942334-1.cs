    public class Customer
    {
        public Customer()
        {
            this.Scores = new List<int>();
        }
        public IList<int> Scores { get; private set; }
    }
