    public List<CustomerEntity> GetCustomerList()
    {
        using (DbConnection connection = CreateConnection())
        {
            return connection.Query<CustomerEntity>("procToReturnCustomers", commandType: CommandType.StoredProcedure).ToList();
        }
    }
