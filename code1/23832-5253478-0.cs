        public static bool DataViewColumnExists(DataView dv, string columnName) { return DataTableColumnExists(dv.Table, columnName); }
        public static bool DataTableColumnExists(DataTable dt, string columnName) {
            string DebugTrace = "Utils::DataTableColumnExists(" + dt.ToString() + ")";
            try { return dt.Columns.Contains(columnName); }
            catch (Exception ex) { throw new MyExceptionHandler(ex, DebugTrace); }
        }
