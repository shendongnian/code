    string custName;
    var customer = order.FirstOrDefault(s => s.Key == "o123");
    if (customer != null)
    {
       custName = customer.Value;
    }
    else
    {
        // code to handle no match
    }
    
