        private void Filter(DataTable tbl)
        {
            DataRow[] rows = new DataRow[tbl.Rows.Count];
            rows.CopyTo(rows, 0);
            Array.Sort<DataRow>(rows, FilterOrder);
            for (int i = 0; i < rows.Length - 1; i++)
            {
                if ((string)rows[i][0] != (string)rows[i + 1][0])
                    continue;
                if ((DateTime)rows[i][1] != (DateTime)rows[i + 1][1])
                    continue;
                rows[i][3] = 0;
            }
        }
        private int FilterOrder(DataRow row1, DataRow row2)
        {
            string r1c1 = (string)row1[0];
            string r2c1 = (string)row2[0];
            if (r1c1 != r2c1) return r1c1.CompareTo(r2c1);
            DateTime r1c2 = (DateTime)row1[1];
            DateTime r2c2 = (DateTime)row2[1];
            if (r1c2 != r2c2) return r1c2.CompareTo(r2c2);
            DateTime r1c3 = (DateTime)row1[2];
            DateTime r2c3 = (DateTime)row2[2];
            return r1c3.CompareTo(r2c3);
        }
