    DateTime d1 = DateTime.Now;
    DateTime d2 = d1 + TimeSpan.FromSeconds(20);
    
    if(d1 == d2.Within(TimeSpan.FromMinutes(1))) {
        // TRUE! Do whatever
    }
