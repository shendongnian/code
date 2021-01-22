    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1 {
    
        class Customer {
            public int id;
            public string name;
        }
    
        class Monkey {
    
            public void AcceptsObject(object list) {
    
                if (list is List<Customer>) {
                    List<Customer> customerlist = list as List<Customer>;
                    foreach (Customer c in customerlist) {
                        Console.WriteLine(c.name);
                    }
                }
            }
        }
    
        class Program {
            static void Main(string[] args) {
    
                Monkey monkey = new Monkey();
                List<Customer> customers = new List<Customer> { new Customer() { id = 1, name = "Fred" } };
                monkey.AcceptsObject(customers);
                Console.ReadLine();
            }
        }
    }
