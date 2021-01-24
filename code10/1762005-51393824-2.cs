    public class SubmitOrder<T>
    {
        private T _country;
        public Country { get; set; }
        public SubmitOrder(T country) => Country = country;
    }
