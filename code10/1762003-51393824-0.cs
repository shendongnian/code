    public class SubmitOrder<T>
    {
        private T _country;
        public SubmitOrder(T country)
        {
            _country = country;
        }
        public T Country
        {
            get { return _country; }
            set { _country = value; }
        }
    }
