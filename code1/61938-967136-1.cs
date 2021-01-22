    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication11
    {
        public class Customer
        {
            public Int32 CustomerId;
            public Int32 CustomerName;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var checks = new List<Customer>();
                var query = from c in checks
                            group c by String.Format("{0} - {1}", c.CustomerId, c.CustomerName)
                                into customerGroups
                                select new { Customer = customerGroups.Key, Payments = customerGroups };
            }
        }
    }
