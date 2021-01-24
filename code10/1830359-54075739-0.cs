                DataTable dt1 = new DataTable();
                DataTable dt2 = dt1.Clone();
                //change columns type
                dt2.Columns["Col A"].DataType = typeof(DateTime);
                int colNumber = dt2.Columns.IndexOf("Col A");
                foreach (DataRow row in dt1.AsEnumerable())
                {
                    object[] rowData = row.ItemArray;
                    rowData[colNumber] = DateTime.Parse(row.Field<string>("Col A"));
                    dt2.Rows.Add(rowData);
                }
