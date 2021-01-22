    private static bool DataRowReallyChanged(DataRow row)
        {
            if (row == null)
            {
                return false;
            }
            if (!row.HasVersion(DataRowVersion.Current) || (row.RowState == DataRowState.Unchanged))
            {
                return false;
            }
            foreach (DataColumn c in row.Table.Columns)
            {
                if (row[c, DataRowVersion.Current].ToString() != row[c, DataRowVersion.Original].ToString())
                {
                    return true;
                }
            }
            return false;
        }
