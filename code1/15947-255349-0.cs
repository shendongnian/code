    SqlDataAdapter sqlDa = new SqlDataAdapter();
    SqlCommand selectCmd = new SqlCommand();
    selectCmd.CommandText = "spReturnMultpileResultSets";
    selectCmd.CommandType = CommandType.StoredProcedure;
    selectCmd.Connection = this.sqlConnection1;
    sqlDa.SelectCommand = selectCmd;
    // Add table mappings to the SqlDataAdapter
    sqlDa.TableMappings.Add("Table", "Customers");
    sqlDa.TableMappings.Add("Table1", "Orders");
    
    // DataSet1 is a strongly typed DataSet
    DataSet1 ds = new DataSet1();
    this.sqlConnection1.Open();
   
    sqlDa.Fill(ds);
    this.sqlConnection1.Close();
