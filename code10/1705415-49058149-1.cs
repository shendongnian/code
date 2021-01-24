    public class ClassB {
        private static ClassB _Instance;
        public static ClassB Instance {
            get {
                if(_Instance==null) _Instance = new ClassB();
                return _Instance;
            }
        }
        public List<Customer> CustomerList = new List<Customer>();
        public void AddToList(Contact inData)
        {
            Customer cm = new Customer();
            cm.Contact = inData;
            cm.Id = GetId();
            CustomerList.Add(cm);
        }
    }
