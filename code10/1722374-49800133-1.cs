    private void InsertOrUpdate(ServiceMonitoring sm)  
    {
        try
        {
            //this brand new DbContext instance has not queried your database, and is not tracking any objects!
            using (var context = new MyDBEntities())  
            {
                //if (sm.serviceName is null) <- should never be null, as it's the ServiceMonitoring object you are passing into the function.
                //The DbContext.Entry() does not know whether or not this actually exists in the database, it only allows you to inform
                //EF about the state of the object.
                context.Entry(sm).State = sm.serviceName == null ?  //<- Always false (unless you *really* want a serviceName to not have a name)
                    EntityState.Added : // <- code unreachable
                    EntityState.Modified; //This is where the exception occurs, your code is always generating an UPDATE statement.
                                            //When the entry exists in the database, EF's generated UPDATE statement succeeds.
                                            //When the entry does not exist, the UPDATE statement fails.
                context.SaveChanges();
            }
            log.Info("ServiceMonitoring updated");
        }
        catch (Exception ex)
        {
            log.Error("Error updating ServiceMonitoring");
            log.Debug(ex.Message);
        }
    }
