    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackOverFlow
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var customers = new List<Customer>();
    
                customers.Add(new Customer { Location = 1, Slots = new List<int>() { 1, 2 } });
                customers.Add(new Customer { Location = 2, Slots = new List<int>() { 3, 4 } });
    
                var location = customers.FirstOrDefault(x => x.Slots.Any(s => s == 4))?.Location;
    
                Console.WriteLine(location); // returns 2
                Console.ReadKey();
            }
        }
    
        public class Customer
        {
            public int Location { get; set; }
            public List<int> Slots { get; set; }
        }
    }
