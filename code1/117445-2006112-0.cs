            HashSet<int> ids = new HashSet<int>();
            DataColumn col = table.Columns["ID"];
            foreach (DataRow row in table.Rows)
            {
                ids.Add((int)row[col]);
            }
            var missing = list.Where(item => !ids.Contains(item.ID)).ToList();
