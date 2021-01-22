    public IEnumerable<ICustomer> Customers()
    {
            foreach( ICustomer item in m_maleCustomers )
            {
                yield return item;
            }
            foreach( ICustomer item in m_femaleCustomers )
            {
                yield return item;
            }
            // or add some constraints...
            foreach( ICustomer customer in m_customers )
            {
                if( customer.Age < 16 )
                {
                    yield return customer;
                }
            }
    }
