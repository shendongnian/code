        public static bool ChangeColumnDataType(DataTable table,string columnname,Type newtype)
        {
            if (table.Columns.Contains(columnname) == false)
                return false;
            
            DataColumn newcolumn = table.Columns[columnname];
            if (newcolumn.DataType == newtype)
                return true;
            try
            {
                table.Columns.Add(new DataColumn("temperary", newtype));
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        row["temperary"] = Convert.ChangeType(row[columnname], newtype);
                    }
                    catch
                    {
                    }
                }
                table.Columns.Remove(columnname);
                newcolumn.ColumnName = columnname;
            }
            catch (Exception)
            {
                return false;
            }
            
            return true;
        }
