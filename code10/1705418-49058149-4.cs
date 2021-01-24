    public class ClassB {
        public static List<Customer> CustomerList = new List<Customer>();
        public void AddToList(Contact inData)
        {
            Customer cm = new Customer();
            cm.Contact = inData;
            cm.Id = GetId();
            CustomerList.Add(cm);
        }
    }
