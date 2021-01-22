    public static List<Customer> GetFilteredCustomersDynamic(List<Customer> customers, Expression<Func<Customer, bool>> whereClause)
        {
            return customers.Where(whereClause.Compile()).ToList();
            
        }
