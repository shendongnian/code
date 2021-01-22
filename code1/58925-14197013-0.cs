    //Try changing values of cells.
    
                foreach (DataRow row in dtPr.Rows)
                {
                    for (int i = 0; i < dtPr.Columns.Count; i++)
                    {
                        
                    dtPr.Columns[i].ReadOnly = false;
                        if (string.IsNullOrEmpty(row[i].ToString()))
                        {
                            if (dtPr.Columns[i].DataType == typeof(string))
                                row[i] = string.Empty;
                            else if (dtPr.Columns[i].DataType == typeof(int))
                                row[i] = 0;
                            else if (dtPr.Columns[i].DataType == typeof(DateTime))
                                row[i] = new DateTime(1753, 1, 1);
                        }
                    }
                }
