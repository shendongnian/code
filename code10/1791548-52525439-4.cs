    public class Customer
        {
            public Guid CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerTelNo { get; set; }
    
            
            private readonly IList<Branch> _branches = new List<Branch>();
            public IEnumerable<Branch> Branches 
            {
                get { return _branches; }
            }
    
            // internal method to add branch to customer. will be called in the public method on branch's side
            internal void AddBranch(Branch branch) 
            {
                if (!_branches.Contains(branch)) _branches.Add(branch);
            }
    
            public Customer(string customername, string customeraddress, string customeremail, string customertelno) 
            {
                CustomerID = Guid.NewGuid();
                this.CustomerName = customername;
                this.CustomerAddress = customeraddress;
                this.CustomerEmail = customeremail;
                this.CustomerTelNo = customertelno;
            }
    
        }
