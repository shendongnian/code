    public class CustomerForUI
    {
        private string _FullName;
        public CustomerForUI(Customer c)
        {
           _FullName = c.FirstName + " " + c.LastName;
        }
        public string FullName
        {
           get {return _FullName;}
        }
        public string CustomerKey
        {  ... }
    }
