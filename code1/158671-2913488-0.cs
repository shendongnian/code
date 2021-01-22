    public class ChooseCustomerModel {
        public Order Order { get; set; }
        // Project Customer objects into this container, which is easy to bind to
        public IDictionary<int, string> PotentialCustomers { get; set; }
    }
