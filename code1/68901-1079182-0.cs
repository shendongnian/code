    using System;
    using System.Data;
    
    class Test
    {
        static void Main()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Country", typeof(string)));
            dt.Columns.Add(new DataColumn("State", typeof(string)));
            
            DataRow dn = dt.NewRow();
            dn["Country"] = "0";
            dn["State"] = "0";
            
            if (dn["Country"].ToString() != "0" &&
                dn["State"].ToString() != "0")
            {
                Console.WriteLine("Broken");
                dt.Rows.Add(dn);
            }
            else
            {
                Console.WriteLine("Working");
            }
        }
    }
