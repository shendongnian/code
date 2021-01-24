    if (customer != null)
    {
        using (CustomersEntities entities = new CustomersEntities())
        {
            Customer updatedCustomer = (from c in entities.Customers
                                        where c.CustomerId == customer.CustomerId
                                        select c).FirstOrDefault();
            updatedCustomer.Nome = customer.Nome;
            updatedCustomer.Tipo = customer.Tipo;
            updatedCustomer.NCM = customer.NCM;
            updatedCustomer.Contabil = customer.Contabil;
            // if EF auto-tracking is disabled, this line is mandatory 
            entities.Entry(updatedCustomer).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
        }
    }
