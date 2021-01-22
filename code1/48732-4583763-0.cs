    public static class ConvertToDataTable
    {
        #region "Converting ObjectArray to Datatable"
        /// <summary>
        /// Method to Convert Datatable from object Array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static DataTable ConvertToDatatable(this Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }
        /// <summary>
        /// Method To Create total column of datatable.
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                //dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }
        /// <summary>
        /// Method for Fill data in DataTable.
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="dt"></param>        
        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }
        #endregion
    }
}
