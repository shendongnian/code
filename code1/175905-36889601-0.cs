            DataTable DT = new DataTable();
            DT.Columns.Add("first", typeof(string));
            DT.Columns.Add("second", typeof(string));
            DT.Rows.Add("ss", "test1");
            DT.Rows.Add("sss", "test2");
            DT.Rows.Add("sys", "test3");
            DT.Rows.Add("ss", "test4");
            DT.Rows.Add("ss", "test5");
            DT.Rows.Add("sts", "test6");
            
            var dr = DT.AsEnumerable().GroupBy(S => S.Field<string>("first")).Select(S => S.First()).
                Select(S => new KeyValuePair<string, string>(S.Field<string>("first"), S.Field<string>("second"))).
               ToDictionary(S => S.Key, T => T.Value);
            foreach (var item in dr)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
