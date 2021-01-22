    public Customer ConvertRowToCustomer(DataRow row)
    {
       Customer result = new Customer();
       result.ID = row.Field<int>("ID");
       result.Name = row.Field<string>("CustomerName");
       ..... // and so on
       return result;
    }
