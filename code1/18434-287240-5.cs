          //change this part to suit you
          var query = from n in snowField
                       select new { ID = n.GetHashCode(), n.Position.X, n.Position.Y };
            System.Data.DataTable tbl = new System.Data.DataTable();
            bool buildColumns = false;
            foreach (var item in query)
            {
                Type t = item.GetType();
                var properties = t.GetProperties();
                if(!buildColumns)
                {
                    foreach (var prop in properties)
                    {
                         Type ptype = prop.PropertyType;
                        if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            ptype = prop.GetValue(item, null).GetType();
                        }
                        DataColumn col = new DataColumn(prop.Name, ptype);
                        tbl.Columns.Add(col);
                    }
                    buildColumns = true;
                }
                System.Data.DataRow row = tbl.NewRow();
               
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item, null);
                }
                tbl.Rows.Add(row);
            }
