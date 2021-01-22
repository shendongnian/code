    public IList<CustomerView> GetAllCustomers()
    {
        ICriteria crit = _session.CreateCriteria (typeof(Customer));
    
        crit.AddProjection ( ... );
    
        crit.SetResultTransformer (new EntityToBeanTransformer(typeof(CustomerView));
    
        return crit.ToList();
    }
