        private void SetUtcDateTime()
        {
            var ds = new DataSet { Locale = CultureInfo.InvariantCulture };
            foreach (DataTable source in DataSet.Tables)
            {
                bool containsDate = false;
                var target = source.Clone();
                foreach (DataColumn col in target.Columns)
                {
                    if (col.DataType == System.Type.GetType("System.DateTime"))
                    {
                        col.DateTimeMode = DataSetDateTime.Utc;
                        containsDate = true;
                    }
                }
                if (containsDate)
                {
                    foreach (DataRow row in source.Rows)
                        target.ImportRow(row);
                    ds.Tables.Add(target);
                }
                else
                {
                    ds.Tables.Add(source.Copy());
                }
            }
            DataSet.Tables.Clear();
            DataSet = ds;
        }
