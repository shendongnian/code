    public DataTable TopDataRow(DataTable dt, int count)
        {
            DataTable dtn = dt.Clone();
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (i < count)
                {
                    dtn.ImportRow(row);
                    i++;
                }
                if (i > count)
                    break;
            }
            return dtn;
        }
