        public static bool DataSetIsEmpty(DataSet ds)
        {
            return !DataTableExists(ds) && !DataRowExists(ds.Tables[0].Rows);
        }
        public static bool DataTableExists(DataSet ds)
        {
            return ds.Tables != null && ds.Tables.Count > 0;
        }
        public static bool DataRowExists(DataRowCollection rows)
        {
            return rows != null && rows.Count > 0;
        }
