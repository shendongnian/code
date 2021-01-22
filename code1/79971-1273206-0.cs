        public void MyDtDemo()
        {
            // A TableAdapter is used to perform the CRUD operations to sync the DataSet/Table and Database
            var myTa = new ClassLibrary4.MyDbTablesTableAdapters.tblCustomersTableAdapter();
            var myDataSet = new MyDbTables();
            // 'Fill' will execute the TableAdapter's SELECT command to populate the DataTable
            myTa.Fill(myDataSet.tblCustomers);
            // Create a new Customer, and add him to the tblCustomers table
            var newCustomer = myDataSet.tblCustomers.NewtblCustomersRow();
            newCustomer.Name = "John Smith";
            myDataSet.tblCustomers.AddtblCustomersRow(newCustomer);
            // Show the pending changes in the DataTable
            var myTableChanges = myDataSet.tblCustomers.GetChanges();
            // Or get the changes by change-state
            var myNewCustomers = myDataSet.tblCustomers.GetChanges(System.Data.DataRowState.Added);
            // Cancel the changes (if you don't want to commit them)
            myDataSet.tblCustomers.RejectChanges();
            // - Or Commit them back to the Database using the TableAdapter again
            myTa.Update(myDataSet);
        }
