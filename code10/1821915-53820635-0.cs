                DataTable dt2 = new DataTable();
                dt2.Columns.Add("NewColumnName1", typeof(int));
                dt2.Columns.Add("NewColumnName2", typeof(string));
                //in this example dt is the original DataTable
                foreach (DataRow dr in dt.Rows)
                {
                              //add only necessary columns by their
                              //ordinal position in source DataTable
                             dt2.Rows.Add(dr[1], dr[0]);
                }
