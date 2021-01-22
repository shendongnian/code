      public DataTable ConvertArrayToDatatable(MarketUnit[] arrList)
        {
            DataTable dt = new DataTable();
            try
            {
                if (arrList.Count() > 0)
                {
                    Type arrype = arrList[0].GetType();
                    dt = new DataTable(arrype.Name);
                    foreach (PropertyInfo propInfo in arrype.GetProperties())
                    {
                        dt.Columns.Add(new DataColumn(propInfo.Name));
                    }
                    foreach (object obj in arrList)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            dr[dc.ColumnName] = obj.GetType().GetProperty(dc.ColumnName).GetValue(obj, null);
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
