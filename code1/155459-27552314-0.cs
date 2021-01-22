    void AddAndPopulateDataTableRowID(DataTable dt, string col, bool isGUID)
        {
            if(isGUID)
                dt.Columns.Add(col, typeof(System.Guid));
            else
                dt.Columns.Add(col, typeof(System.Int32));
            int rowid = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (isGUID)
                    dr[col] = Guid.NewGuid();
                else
                    dr[col] = rowid++;
            }
        }
