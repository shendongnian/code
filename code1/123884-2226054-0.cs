    void Load() {
      using (SqlConnection conn = ...) {
        conn.Open();
        invoicesAdapter.Connection = conn;
        customersAdapter.Connection = conn;
        invoicesAdapter.Fill(dataSet.Invoices);
        customersAdapter.Fill(dataSet.Customers);
      }
    }
    
    void Save() {
      using (SqlConnection conn = ...) {
        conn.Open();
        invoicesAdapter.Connection = conn;
        customersAdapter.Connection = conn;
        invoicesAdapter.Update(dataSet);
        customersAdapater.Update(dataSet);
      }
    }
