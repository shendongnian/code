    CustomerServiceDesk _frontLine = new FrontLineServiceDesk();
    CustomerServiceDesk _criticalLine = new CriticalLineServiceDesk();
    CustomerServiceDesk _legalLine = new LegalLineServiceDesk();
    // hook up events
    _frontLine.OnElevateQuery += _critialLine.ServeCustomer;
    _criticalLine.OnElevateQuery += _legalLine.ServeCustomer;
    Customer _customer1 = new Customer(); 
    _customer1.Name = "Microsoft"; 
    _customer1.ComplaintType = ComplaintType.General; 
 
    Customer _customer2 = new Customer(); 
    _customer2.Name = "SunSystems"; 
    _customer2.ComplaintType = ComplaintType.Critical; 
 
    Customer _customer3 = new Customer(); 
    _customer3.Name = "HP"; 
    _customer3.ComplaintType = ComplaintType.Legal;
    _frontLine.ServeCustomer(_customer1);
    _frontLine.ServeCustomer(_customer2);
    _frontLine.ServeCustomer(_customer3);
    
