            DataTable dt = new DataTable();
            int i = 0;
            foreach (var entry in some)
            {
                if (entry.Value.Count > 0)
                {
                    dt.Columns.Add(entry.Key);
                    DataRow row;
                    //entry.Value.count is not same for all entry.Key                 
                    foreach (var value in entry.Value)
                    {
                        int ValueCount = entry.Value.Count();
                        if (dt.Rows.Count <= ValueCount)
                        {
                            row = dt.NewRow();
                            row[entry.Key] = value;
                            dt.Rows.Add(row);
                        }
                        else
                        {
                            row = dt.Rows[i];
                            row[entry.Key] = value;
                            i++;
                        }
                    }
                }
            }
