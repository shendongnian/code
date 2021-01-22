    using System;
    using System.Collections.Generic;
    
    namespace TestProperty232
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer customer = new Customer() { 
                    FirstName = "Jim",
                    LastName = "Smith"
                };
    
                Contract contract = new Contract() { 
                    Title = "First Contract"
                };
    
                customer.Contracts = new List<Contract>() { contract };
    
                Console.ReadLine();
            }
        }
    
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Contract> Contracts { get; set; }
    
            public Customer()
            {
                //Contracts = new List<Contract>();
            }
        }
    
        public class Contract
        {
            public string Title { get; set; }
        }
    }
