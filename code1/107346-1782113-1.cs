        public static List<Customer> GetFilteredCustomersDynamic(List<Customer> customers, Func<Customer, bool> whereClause)
        {
            return customers
                   .Where(whereClause).ToList();
        }
        public static List<Customer> GetFilteredCustomers(List<Customer> customers, string letter)
        {
            return GetFilteredCustomersDynamic(c => c.LastName.Contains(letter));
        }
