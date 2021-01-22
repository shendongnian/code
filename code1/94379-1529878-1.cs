    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            int size = int.Parse(args[0]);
            int id = int.Parse(args[1]);
            int iterations = int.Parse(args[2]);
            
            var list = new List<Customer>(size);
            for (int i=0; i < size; i++)
            {
                list.Add(new Customer {
                    ID = i, 
                    Address = "Address " + i,
                    Name = "Cusomer Name " + i,
                    Phone= "Phone " + i,
                });
            }
            
            Time(FindCustomerLinq, list, id, iterations);
            Time(FindCustomerListFind, list, id, iterations);
            Time(FindCustomerForLoop, list, id, iterations);
            Time(FindCustomerForEachLoop, list, id, iterations);
        }
    
        static void Time(Func<List<Customer>, int, Customer> action,
                         List<Customer> list,
                         int id, int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i=0; i < iterations; i++)
            {
                action(list, id);
            }
            sw.Stop();
            Console.WriteLine("{0}: {1}", action.Method.Name, (int) sw.ElapsedMilliseconds);
        }
        
        static Customer FindCustomerLinq(List<Customer> customers, int id)
        {
            return customers.FirstOrDefault(c => c.ID == id);
        }
        
        static Customer FindCustomerListFind(List<Customer> customers, int id)
        {
            return customers.Find(c => c.ID == id);
        }
        
        static Customer FindCustomerForLoop(List<Customer> customers, int id)        
        {
            for (int i=0; i < customers.Count; i++)
            {
                if (customers[i].ID == id)
                {
                    return customers[i];
                }
            }
            return null;
        }
        
        static Customer FindCustomerForEachLoop(List<Customer> customers, int id)
        {
            foreach (Customer c in customers)
            {
                if (c.ID == id)
                {
                    return c;
                }
            }
            return null;
        }
    }
