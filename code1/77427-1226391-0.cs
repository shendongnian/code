    public static ICollection<Customer> FindCustomers()
    {
            try
            {
               return DAL.GetCustomers();
             }
            }
            catch (Exception ex)
            {
                //log here
                throw;
            }
    }
