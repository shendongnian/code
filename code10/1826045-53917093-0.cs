                DataTable dt = new DataTable();
                Dictionary<string, DataTable> dict = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Col A"), y => y)
                    .ToDictionary(x => x.Key, y => y.CopyToDataTable());
                foreach (KeyValuePair<string, DataTable> key in dict.AsEnumerable())
                {
                    int numberColumns = key.Value.Columns.Count;
                    for (int i = numberColumns - 1; i >= 0; i--)
                    {
                        key.Value.AsEnumerable().OrderBy(x => x[i]);
                    }
                }
