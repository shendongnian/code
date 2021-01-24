    public List<Customer> CustomersGetAll()
    {
        var customers = new List<Customer>();
        Customer customer;
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(connection))
        {
            // do work...
