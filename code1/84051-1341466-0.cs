    var customers = _db.Customers; // Not necessary, but here for clarity
    
    // ... more code
    
    // Access the number of bills for each customer:
    
    foreach (var customer in customers)
    {
        int totalBills = customers.Bills.Count();
        int totalDueBills customers.Bills.Where(b => b.IsDue).Count();
    }
