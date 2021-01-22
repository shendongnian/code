    class DataTableTrimmer {
        private DataTable dt;
        public DataTableTrimmer(DataTable pDt) {
            dt = pDt;
        }
    
        public void TrimAllDataInDataTable()
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    row[dc] = row[dc].ToString().Trim();
                }
            }
        }
        ...
    }
