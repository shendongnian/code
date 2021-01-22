            for (int h = 0; h < table.Rows.Count; h++)
            {
                if (table.Rows[h].IsNull(0) == true)
                {
                    table.Rows[h].Delete();
                }enter code here
            }
            table.AcceptChanges();
            foreach (var column in table.Columns.Cast<DataColumn>().ToArray())
            {
                if (table.AsEnumerable().All(dr => dr.IsNull(column)))
                    table.Columns.Remove(column);
            }
            table.AcceptChanges();           
        }
