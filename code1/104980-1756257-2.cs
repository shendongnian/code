    private void ReadDB()
    {
       try
       {
           string connectionString = "server=(local)\\SQLEXPRESS;" +
                 "Trusted_Connection=yes; database=INVENTORY";
           myConnection = new SqlConnection(connectionString);
           myConnection.Open();
           myDataSet = new DataSet();
           myDataSet.CaseSensitive = true;
           DataAdapter = new SqlDataAdapter();
           DataAdapter = CreateInventoryAdapter();
           DataAdapter.TableMappings.Add("Table", "INVENTORY");
               
           DataAdapter.Fill(myDataSet);
       } catch (Exception ex) { // Do Something }
    }
    private SqlDataAdapter CreateInventoryAdapter()
    {
         SqlDataAdapter adapter = new SqlDataAdapter();
         ....
         command = new SqlCommand("SELECT * FROM INVENTORY", myConnection);
         adapter.SelectCommand = command;
         return adapter;
         ....
    }
   
