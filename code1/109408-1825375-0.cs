    using System.Collections.Generic;
    namespace proto
    {
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Contract
        {
            public List<Customer> Customers { get; set; }
            public string Title { get; set; }
        }
        public class ContractDemo
        {
            public Contract CreateDemoContract()
            {
                Contract newContract = new Contract
                {
                    Title = "Contract Title", 
                    Customers = new List<Customer>
                    {
                        new Customer
                        {
                            FirstName = "First Name",
                            LastName = "Last Name"
                        },
                        new Customer
                        {
                            FirstName = "Other",
                            LastName = "Customer"
                        }
                    }
                };
                return newContract;
            }
    
        }
    }
