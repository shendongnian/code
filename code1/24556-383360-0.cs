    Customer ProvideCustomer(int ID)
    {
        Customer result; // or initialize to null to signal more work to come
        DataTable dt = DataAccess.GetCustomer(ID);
        if (dt.Rows.Count > 0)
        {
            result = new Customer( dt.getappropriaterow ) // however you choose one
        }
        else
        {
            result = new Customer();
            result.ID = ID;          // whatever other initialization you need
        }
        return result;
    }
