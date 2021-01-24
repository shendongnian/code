    public class SubmitOrder<T>
    {
        public Country { get; set; }
        public SubmitOrder(T country) => Country = country;
    }
