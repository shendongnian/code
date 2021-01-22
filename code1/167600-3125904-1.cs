    DataSet myDataset = new DataSet();
    DataTable customers = myDataset.Tables.Add("Customers");
    customers.Columns.Add("Name");
    customers.Columns.Add("Age");
    customers.Rows.Add("Chris", "25");
    //Get data
    DataTable myCustomers = myDataset.Tables["Customers"];
    DataRow currentRow = null;
    for (int i = 0; i < myCustomers.Rows.Count; i++)
    {
        currentRow = myCustomers.Rows[i];
        listBox1.Items.Add(string.Format("{0} is {1} YEARS OLD", currentRow["Name"], currentRow["Age"]));    
    }
