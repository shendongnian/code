    public ObservableCollection<Customer> Customers {get;set;}
    public Func<Customer,Task> ScrollToCustomer {get;set;}
    public DelegateCommand FindBestCustomer {get;set;} // For example    
    FindBestCustomer = new DelegateCommand(async() => 
    { 
    	Customer bestCustomer = Customers.Last(); // this is our logic in view model!
    	await ScrollToCustomer(bestCustomer);
    	// at this time, scroll is finished.
    });
