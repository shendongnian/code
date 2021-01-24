    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Product> products = new List<Product>();
                List<string> keys = products.Select(x => x.AttributeList.Select(y => y.Key)).SelectMany(x => x).Distinct().ToList();
                DataTable pivot = new DataTable();
                pivot.Columns.Add("Id", typeof(long));
                pivot.Columns.Add("Name", typeof(string));
                pivot.Columns.Add("ReferenceNumber", typeof(string));
                pivot.Columns.Add("Category", typeof(string));
                foreach (string key in keys)
                {
                    pivot.Columns.Add(key, typeof(string));
                }
                foreach (Product product in products)
                {
                    DataRow row = pivot.Rows.Add();
                    row["Id"] = product.Id;
                    row["Name"] = product.Name;
                    row["ReferenceNumber"] = product.ReferenceNumber;
                    row["Category"] = product.Category;
                    foreach (KeyValuePair<string, string> attr in product.AttributeList)
                    {
                        row[attr.Key] = attr.Value;
                    }
                }
            }
        }
        public class Product
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public string ReferenceNumber { get; set; }
            public string Category { get; set; }
            public List<KeyValuePair<string, string>> AttributeList { get; set; }
        }
    }
