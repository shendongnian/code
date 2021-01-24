        public ActionResult UpdateCustomer(Customer customer)
        {
          using (CustomersEntities entities = new CustomersEntities())
           {
              entities.Entry(customer).State = EntityState.Modified;
              entities.SaveChanges();
           }
           return new EmptyResult();
        }
