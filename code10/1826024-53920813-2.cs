    List<string> list = new List<string>()
            {
                "Apple",
                "Banana",
                "Cream"
            };
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Customer where "); 
            list.ForEach((item) =>
            {
                sb.Append("Name='");
                sb.Append(item);
                sb.Append("' Or ");
            });
            sb.Remove(sb.Length - 4, 4);
            RawSqlString sql= new RawSqlString(sb.ToString());
            var result = _context.Customers.FromSql(sql).ToList();
           
