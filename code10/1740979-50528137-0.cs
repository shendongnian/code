    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    using System.Diagnostics;
    using System.Data;
    namespace ConsoleApplication45
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                List<Business> companies = new List<Business>() {
                    new Business() { name = "CompanyA",items = new List<Item>(){ new Item() { name = "Item1"}, new Item() { name = "Item2"}}},
                    new Business() { name = "CompanyB", items = new List<Item>() { new Item() { name = "Item3"}, new Item() { name = "Item4"}}},
                    new Business() { name = "CompanyA",items = new List<Item>(){ new Item() { name = "Item5"}, new Item() { name = "Item6"}}},
                };
                var groups = companies.GroupBy(x => x.name).Select(x => new { business = x.FirstOrDefault(), items = x.SelectMany(y => y.items) });
                List<Business> newCompanies = new List<Business>();
                foreach (var group in groups)
                {
                    Business company = group.business;
                    company.items = group.items.ToList();
                    newCompanies.Add(company);
                }
            }
      
        }
        public class Business
        {
            public string name { get; set; }
            public List<Item> items { get; set; }
            public decimal taxrate { get; set; }
            public string month { get; set; }
        }
        public class Item
        {
            public string name { get;set;}
            public decimal price { get;set;}
            public decimal total { get;set;}
        }
    }
