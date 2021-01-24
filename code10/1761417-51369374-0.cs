    void SetCustomerName(Customer obj) { // for class Customer
        obj.Name = "Fred";
    }
    ...
    var x = new Customer();
    SetCustomerName(x);
    Console.WriteLine(x.Name); // prints "Fred"
