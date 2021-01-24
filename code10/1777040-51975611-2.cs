    private void GenerateDataTable()
    {
        // unique products and customers
        var products = Customers.Select(x => x.Product).Distinct().ToList();
        var customers = Customers.Select(x => x.CustomerNr).Distinct().ToList();
        // columns CustomerNr and Address
        var dataTable = new System.Data.DataTable();
        dataTable.Columns.Add(new DataColumn("CustomerNr"));
        dataTable.Columns.Add(new DataColumn("Address"));
        // columns for each product
        foreach (var product in products)
        {
            dataTable.Columns.Add(new DataColumn(product));
        }
        //fill rows for each customers
        foreach (var customer in customers)
        {
            var row = dataTable.NewRow();
            row["CustomerNr"] = customer;
            row["Address"] = Customers.Where(x => x.CustomerNr == customer).Select(x => x.Address).FirstOrDefault();
            foreach (var product in products)
            {
                var quantity = Customers.Where(x => x.CustomerNr == customer && x.Product == product)
                    .Select(x => x.Quantity).FirstOrDefault();
                row[product] = quantity ?? "0";
            }
            dataTable.Rows.Add(row);
        }
        dataGridView1.DataSource = dataTable;
    }
