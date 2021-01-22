    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace Sorting_ComplexTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer customer1 = new Customer {
                    ID = 101,
                    Name = "Mark",
                    Salary = 2400,
                    Type = "Retail Customers"
                };
                Customer customer2 = new Customer
                {
                    ID = 102,
                    Name = "Brian",
                    Salary = 5000,
                    Type = "Retail Customers"
                };
                Customer customer3 = new Customer
                {
                    ID = 103,
                    Name = "Steve",
                    Salary = 3400,
                    Type = "Retail Customers"
                };
                
                List<Customer> customer = new List<Customer>();
                customer.Add(customer1);
                customer.Add(customer2);
                customer.Add(customer3);
    
                Console.WriteLine("Before Sorting");
                foreach(Customer c in customer)
                {
                    Console.WriteLine(c.Name);
                }
    
                customer.Sort();
                Console.WriteLine("After Sorting");
                foreach(Customer c in customer)
                {
                    Console.WriteLine(c.Name);
                }
    
                customer.Reverse();
                Console.WriteLine("Reverse Sorting");
                foreach (Customer c in customer)
                {
                    Console.WriteLine(c.Name);
                }
                }
            }
        }
        public class Customer : IComparable<Customer>
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public string Type { get; set; }
    
            public int CompareTo(Customer other)
            {
                return this.Name.CompareTo(other.Name);
            }
        }
