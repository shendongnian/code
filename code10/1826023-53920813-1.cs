      List<string> list = new List<string>()
            {
                "Apple",
                "Banana",
                "Cream"
            };
            StringBuilder sb = new StringBuilder();
            list.ForEach((item) =>
            {
                sb.Append("'");
                sb.Append(item);
                sb.Append("'");
                sb.Append(",");
            });
            sb.Remove(sb.Length - 1, 1);//{'Apple','Banana','Cream'}
            RawSqlString raw = new RawSqlString($"select * from Customer where Name in ({sb.ToString()})");
            var result = _context.Customers.FromSql(raw).ToList();
