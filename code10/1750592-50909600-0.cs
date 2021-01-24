    public IEnumerable<tblCustomerType> GetCustomerType()
        {
           // IEnumerable<tblCustomerType> result;
            using (var context = new dbLMSEntities())
            {
                return context.tblCustomerTypes.ToList();
            }
    }
