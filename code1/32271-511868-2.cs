    public class CustomerStore : MyStore, IEnumerable<Customer> {
        List<Customer> list = new List<Customer>();
        public override string Name { get { return "Customer Store"; } }
        public override void AddItem(int id, string name) {
            list.Add(new Customer(id, name));
        }
        public IEnumerator<Customer> GetEnumerator() {
            return list.GetEnumerator();
        }
    }
