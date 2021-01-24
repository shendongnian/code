     public class Branch 
        {
            public Guid BranchID { get; set; }
            public string BranchName { get; set; }
            public string BranchAddress { get; set; }
            public string BranchTelNo { get; set; }
    
            private readonly IList<Customer> _customers = new List<Customer>();
            public IEnumerable<Customer> Customers
            {
                get { return _customers; }
            }
    
            // add two-sided relation. the customer is added to the branch but the branch is add to the customer too
            // IMPORTANT: the relation can be added on one side of the relationship ONLY. 
            // I chose to add customers to branch, but it can be done the other way around
            public void AddCustomer(Customer customer) 
            {
                if (_customers.Contains(customer)) return;
                _customers.Add(customer);
                customer.AddBranch(this); // internal method is being called and branch is added to customer
    
            }
    
            public Branch(string branchname, string branchaddress, string branchtelno) 
            {
                this.BranchID = Guid.NewGuid();
                this.BranchName = branchname;
                this.BranchAddress = branchaddress;
                this.BranchTelNo = branchtelno;
            }
       
        }
