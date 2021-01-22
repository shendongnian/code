    using System;
    using System.Data;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            DataTable table = new DataTable();
            table.Columns.Add("userid");
            table.Columns.Add("phone");
            table.Columns.Add("email");
            
            table.Rows.Add(new[] { "1", "9999999", "test@test.com" });
            table.Rows.Add(new[] { "2", "1234567", "foo@test.com" });
            table.Rows.Add(new[] { "3", "7654321", "bar@test.com" });
            
            var query = from row in table.AsEnumerable()
                        select new {
                            userid = (string) row["userid"],
                            phone = (string) row["phone"],
                            email = (string) row["email"]            
                        };
            
            JObject o = JObject.FromObject(new
            {
                Table = query
            });
            
            Console.WriteLine(o);
        }
    }
