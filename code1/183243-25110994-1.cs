                    DataTable dt = new DataTable();
                    using (IDataReader dr = com.ExecuteReader())
                    {
                        if (dr.FieldCount > 0)
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                DataColumn dc = new DataColumn(dr.GetName(i), dr.GetFieldType(i));
                                dt.Columns.Add(dc);
                            }
                            object[] rowobject = new object[dr.FieldCount];
                            while (dr.Read())
                            {
                                dr.GetValues(rowobject);
                                dt.LoadDataRow(rowobject, true);
                            }
                        }
                    }
                    return dt;
