        TableBatchOperation batchOperation = new TableBatchOperation();
        DateTime dts = DateTime.Now;
        DateTime dte = DateTime.UtcNow;
        // Create a customer entity and add it to the table.
        CustomerEntity customer1 = new CustomerEntity("Smith", "Jeff");
        customer1.Order = 1;
        customer1.StartDate = Convert.ToString(dts);
        customer1.EndDate = Convert.ToString(dte);
        customer1.Text = "text1";
        // Create another customer entity and add it to the table.
        CustomerEntity customer2 = new CustomerEntity("Smith", "Ben");
        customer2.Order = 2;
        customer2.StartDate = Convert.ToString(dts);
        customer2.EndDate = "";
        customer2.Text = "text2";
        CustomerEntity customer3 = new CustomerEntity("Smith", "Cai");
        customer3.Order = 3;
        customer3.StartDate = "";
        customer3.EndDate = "";
        customer3.Text = "text3";
        // Add both customer entities to the batch insert operation.
        batchOperation.Insert(customer1);
        batchOperation.Insert(customer2);
        batchOperation.Insert(customer3);
        // Execute the batch operation.
        table.ExecuteBatch(batchOperation);
