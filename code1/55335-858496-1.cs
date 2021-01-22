    // the parameter is there to conform to the signature of the WaitDelegate
    // used when invoking the method using the ThreadPool
    public void Search(object state)
    {    
        List<Customer> result = new List<Customer>();
        // perform the search, populate the result list
        // call a method to raise the event
        OnSearchFinished(new CustomerSearchEventArgs(result));
    }
    
    protected void OnSearchFinished(CustomerSearchEventArgs e)
    {
        EventHandler<CustomerSearchEventArgs> searchFinished = this.SearchFinished;
        if (searchFinished != null)
        {
            searchFinished(this, e);
        }
    }
