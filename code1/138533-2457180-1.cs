    public IList<Customer> GetCustomers()
    {
        StringBuilder sql = new StringBuilder();
        sql.Append(" SELECT CustomerId, CompanyName, City, Country ");
        sql.Append("   FROM Customer ");
       
        DataTable dt = Db.GetDataTable(sql.ToString());
        return MakeCustomers(dt);
    }
