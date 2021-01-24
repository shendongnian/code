    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication31
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Server", typeof(string));
                dt.Columns.Add("Source", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Version", typeof(string));
                dt.Rows.Add(new object[] { "Server1", "Database", "MySQL",  "5.5"});
                dt.Rows.Add(new object[] { "Server2", "Database", "MySQL",  "5.1"});
                dt.Rows.Add(new object[] { "Server3", "OS",       "Ubuntu", "10.04"});
                dt.Rows.Add(new object[] { "Server1", "OS",       "Ubuntu", "10.04"});
                dt.Rows.Add(new object[] { "Server2", "OS",       "Ubuntu", "12.04"});
                dt.Rows.Add(new object[] { "Server2", "OS",       "Ubuntu", "12.04"});
                dt.Rows.Add(new object[] { "Server3", "Language", "Python", "2.6.3"});
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<string>("Version")).ToList();
                var results = groups.Where(x => x.Count() > 1).Select(x => new { key = x.Key, count = x.Count() });
                foreach(var item in results)
                {
                    Console.WriteLine("Version : '{0}' Occurances : '{1}'", item.key, item.count);
                }
                Console.ReadLine();
            }
     
        }
    }
