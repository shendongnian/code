    //Get Column from Source table 
      string sourceTableQuery = "Select top 1 * from sourceTable";
       DataTable dtSource=SQLHelper.SqlHelper.ExecuteDataset(transaction, CommandType.Text, sourceTableQuery).Tables[0];// i use sql helper for executing query you can use corde sw
    
     for (int i = 0; i < destinationTable.Columns.Count; i++)
                            {    //check if destination Column Exists in Source table
                                if (dtSource.Columns.Contains(destinationTable.Columns[i].ToString()))//contain method is not case sensitive
                                {
                                    int sourceColumnIndex = dtSource.Columns.IndexOf(destinationTable.Columns[i].ToString());//Once column matched get its index
                                    bulkCopy.ColumnMappings.Add(dtSource.Columns[sourceColumnIndex].ToString(), dtSource.Columns[sourceColumnIndex].ToString());//give coluns name of source table rather then destination table so that it would avoid case sensitivity
                                }
    
                            }
                            bulkCopy.WriteToServer(destinationTable);
                            bulkCopy.Close();
