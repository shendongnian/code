    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var items = getItems("Item 1");
    
                foreach (var item in items)
                {
                    Console.WriteLine("Id: {0}", item.id);
                    Console.WriteLine("Name: {0}", item.name);
                    Console.WriteLine("Price: {0}", item.price);
                    Console.ReadLine();
                }
            }
    
            public static IList<Item> getItems(string name)
            {
                using (IDbConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=test;Integrated Security=True"))
                {    
                    return connection.Query<Item>($"SELECT * FROM ITEM WHERE name = @name",
                        new { name }).ToList();
                }
            }
        }
    
        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public float price { get; set; }
        }
    }
