    // regular parsing
    int i = "123".Parse<int>(); 
    int? inull = "123".Parse<int?>(); 
    DateTime d = "01/12/2008".Parse<DateTime>(); 
    DateTime? dn = "01/12/2008".Parse<DateTime?>();
    
    // null values
    string sample = null;
    int? k = sample.Parse<int?>(); // returns null
    int l = sample.Parse<int>();   // returns 0
    DateTime dd = sample.Parse<DateTime>(); // returns 01/01/0001
    DateTime? ddn = sample.Parse<DateTime?>(); // returns null
