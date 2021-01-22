    private static SelectList LoadItems<T>() where T : new
    {
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
