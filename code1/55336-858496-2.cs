    private delegate void CustomerListHandler(List<Customer> customers);
    private void StartSearch()
    {
        CustomerSearch search = new CustomerSearch();
        search.SearchFinished += new EventHandler<CustomerSearchEventArgs>(Search_SearchFinished);
        ThreadPool.QueueUserWorkItem(search.Search);
    }
    private void Search_SearchFinished(object sender, CustomerSearchEventArgs e)
    {
        SearchFinished(e.Customers);
    }
    
    private void SearchFinished(List<Customer> list)
    {
        if (this.InvokeRequired)
        {
            // the method is NOT executing on the UI thread; we
            // need to invoke it on the right thread
            this.Invoke(new CustomerListHandler(SearchFinished), list);
        }
        else
        {
            lstCustomers.Items.Clear();
            lstCustomers.DisplayMember = "Name";
            lstCustomers.Items.AddRange(list.ToArray());
        }
    }
