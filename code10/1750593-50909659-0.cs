    public IQueryable GetCustomerType()
    {
       // IEnumerable<tblCustomerType> result;
        using (var context = new dbLMSEntities())
        {
           var  x = (from c in context.tblCustomerTypes
                     select new 
                     {
                         c.CustomerTypeID,
                         c.CustomerType
                     });
            return x;
        }
    }
