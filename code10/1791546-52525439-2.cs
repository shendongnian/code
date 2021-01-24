      public class Organization 
            {
                // add cutmoer to the branch
                public void AddCustomers(Branch branch, Customer customer) 
                {
                    branch.AddCustomer(customer);
                    
                }
    
                
                // search through List of branches for customer name. upon finding, print the customer and the branch details            
                public void SearchCustomer(string customername,IEnumerable<Branch> branches) 
                {
    
                    
                    foreach (var branch in branches)
                    {
                        foreach (var customer in branch.Customers)
                        {
    
                            if (customername == customer.CustomerName) 
                            {
                                Console.WriteLine("The customer you looked up:" + customername + "  " + customer.CustomerEmail + "  " + customer.CustomerTelNo);
                                Console.WriteLine("is a customer in branch:");
                                Console.WriteLine(branch.BranchName + "  " + branch.BranchAddress);
    
    
                            }
                        }
                    }
                                    
                }
            }
