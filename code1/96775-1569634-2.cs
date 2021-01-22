    Customer MyCustomer = (
    	from cust in myDatabase.Customers
    	where cust.CustomerID == userPassedCustomerID
    	select cust).Single();
    
    Console.WriteLine(MyCustomer.FullName);
    
    MyCustomer.PersonalizedGreeting = userPassedGreeting;
    myDatabase.SubmitChanges();
