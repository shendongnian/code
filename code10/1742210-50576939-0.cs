      private static void CopyValues(DataTable source, ref DataTable dest)
        {
            double roundValue;
            foreach (DataRow sourcerow in source.Rows)
            {
                //create new row in based on dest table 
                DataRow destRow = dest.NewRow();
                foreach (DataColumn colname in dest.Columns)
                {
                        if (Double.TryParse(sourcerow[colname.ColumnName].ToString(), out roundValue) && dest.Columns[colname.ColumnName].Ordinal != 0)
                        {
                            
                            if (colname.ColumnName.Contains("%"))
                            {
                                destRow[colname.ColumnName] = string.Format(new CultreInfo("en-US"), "{0} %", roundValue);
                            }
                            else
                            {
                                //if the value is in double format /numerical format then we store it in format of c2 i.e. "0.00"
                                //add data to column
                                destRow[colname.ColumnName] = roundValue.ToString("c2");
                            }
                        }
                        else if (sourcerow[colname.ColumnName].GetType() == typeof(DateTime))
                        {
                            //if the data is in form of date time then convert it to d/MM/YYYY format
                            destRow[colname.ColumnName] = Convert.ToDateTime(sourcerow[colname.ColumnName]).ToString("d/MM/yyyy");
                        }
                        else
                        {
                            //if the data is of any other form simply add it to dest datatable
                            destRow[colname.ColumnName] = sourcerow[colname.ColumnName].ToString();
                        }
                    }
                }
                //add row to datatable 
                dest.Rows.Add(destRow);
            }
        }
 
   
