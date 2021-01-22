    private static SelectList LoadItems<T>() where T : new, ... 
    {                                                // Add any additional interfaces
                                                     // that need to be supported by T
                                                     // for your Load method to work,
                                                     // as appropriate.
        IList<T> items;
        try
        {
            IServiceCallService scService = new ServiceCallService();
            results = scService.Get<T>();  // You'll need to replace GetCustomers() with
                                           //   a generic Get<T> method.
            // ...
        }
        catch
        {
            // ...
        }
        return new SelectList(items, "ID", "Name");
    }
