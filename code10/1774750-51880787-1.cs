                DataTable products = new DataTable("Products");
                products.Columns.Add("ID", typeof(string));
                products.Columns.Add("No_of_Products", typeof(int));
                products.Columns.Add("Lac_ID", typeof(string));
                products.Rows.Add(new object[] {"001", 5, "100"});
                products.Rows.Add(new object[] {"002", 6, "300"});
                products.Rows.Add(new object[] {"003", 2, "400"});
                products.Rows.Add(new object[] {"004", 2, "200"});
                DataTable details = new DataTable("Cus_details");
                details.Columns.Add("ID", typeof(string));
                details.Columns.Add("CUS_ID", typeof(string));
                details.Rows.Add(new object[] {"100", "CUS001"});
                details.Rows.Add(new object[] {"200", "CUS002"});
                details.Rows.Add(new object[] {"300", "CUS003"});
                details.Rows.Add(new object[] {"400", "CUS004"});
                var results = (from p in products.AsEnumerable()
                               join d in details.AsEnumerable() on p.Field<string>("Lac_ID") equals d.Field<string>("ID")
                               select new { customer = d.Field<string>("CUS_ID"), number = p.Field<int>("No_of_Products") }).ToList();
