    string a = "-1"; // These are values that are configurable based on which date is checked. Yesterday means, -1 for example. 
    string b = "-15"; // -15 means within last 15 days.
    DateTime d = new DateTime();
    DateTime e = d.AddDays(int.Parse(a));
    if (DateTime.Now.Date >= d.Date && e.Date <= d.Date)
    {
    
    }
