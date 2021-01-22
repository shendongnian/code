            First.TableName = "FirstTable";
            Second.TableName = "SecondTable";
            //Create Empty Table
            DataTable table = new DataTable("Difference");
            DataTable table1 = new DataTable();
            try
            {
                //Must use a Dataset to make use of a DataRelation object
                using (DataSet ds4 = new DataSet())
                {
                    //Add tables
                    ds4.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });
                    //Get Columns for DataRelation
                    DataColumn[] firstcolumns = new DataColumn[ds4.Tables[0].Columns.Count];
                    for (int i = 0; i < firstcolumns.Length; i++)
                    {
                        firstcolumns[i] = ds4.Tables[0].Columns[i];
                    }
                    DataColumn[] secondcolumns = new DataColumn[ds4.Tables[1].Columns.Count];
                    for (int i = 0; i < secondcolumns.Length; i++)
                    {
                        secondcolumns[i] = ds4.Tables[1].Columns[i];
                    }
                    //Create DataRelation
                    DataRelation r = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);
                    ds4.Relations.Add(r);
                    //Create columns for return table
                    for (int i = 0; i < First.Columns.Count; i++)
                    {
                        table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                    }
                    //If First Row not in Second, Add to return table.
                    table.BeginLoadData();
                    foreach (DataRow parentrow in ds4.Tables[0].Rows)
                    { 
                        DataRow[] childrows = parentrow.GetChildRows(r);
                      
                        if (childrows == null || childrows.Length == 0)
                            table.LoadDataRow(parentrow.ItemArray, true);
                        table1.LoadDataRow(childrows, false);
                        
                    }
                    table.EndLoadData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return table;
        }
