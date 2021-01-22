    class Customer
    {
        public Customer(int id, string firstName, string lastName)
        {
            //...
        }
        static public Customer MapFromDataRow(DataRow dr)
        {
            return new Customer(
                dr["ID"],
                dr["FirstName"],
                dr["LastName"]);
        }
        static public Customer LoadFromDatabaseId(int id)
        {
            DataTable dt = DataAccess.GetCustomer(ID);
            if (dt.Rows.Count > 0)    
            {
                return MapFromDataRow(dt.Rows[0]);
            }
            else    
            {        
                throw new CustomerNotFoundException(id);                
            } 
        }
    }
