    class CustomerMessage
    {
        private string name;
        private List<Action<Customer>> changeTrackingMethods =
            new List<Action<Customer>>();
    
        public int Id { get; set; }
    
        public string Name {
            get { return this.name; }
            set
            {
                this.name = value;
                this.changeTrackingMethods.Add(c => { c.SetName(value) });
            }
        }
    
        public void ApplyChanges(Customer c)
        {
            foreach (var action in this.changeTrackingMethods)
            {
                action(c);
            }
        }
    }
