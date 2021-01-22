    [DataContract]
    public class Rating
    {
        private Customer _customer;
        //[DataMember] // <-  EITHER HERE 
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
    }
    
    
    [DataContract]
    public class Customer
    {
        private long _customerID;
        [DataMember]
        public long CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
    
        [DataMember] // <- OR HERE
        public Rating Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
    }
